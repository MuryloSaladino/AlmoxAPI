using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Almox.Application.Contracts;

namespace Almox.API.Middlewares;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app) =>
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is null) return;

                var extractor = ResolveExtractor(contextFeature.Error, context.RequestServices);
                var errorSummary = extractor.Extract(contextFeature.Error);

                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)errorSummary.StatusCode;

                var errorResponse = JsonSerializer.Serialize(new
                {
                    statusCode = errorSummary.StatusCode,
                    message = errorSummary.Message,
                    details = errorSummary.Details
                });
                await context.Response.WriteAsync(errorResponse);
            });
        });
    
    private static IErrorSummaryExtractor<Exception> ResolveExtractor(
        Exception error, IServiceProvider services)
    {
        var errorType = error.GetType();
        var extractorType = typeof(IErrorSummaryExtractor<>).MakeGenericType(errorType);
        var extractorInstance = services.GetService(extractorType);

        return new DynamicErrorSummaryHandler(extractorInstance);
    }
}