using System.Text.Json;
using Almox.Application.Contracts;
using Microsoft.AspNetCore.Diagnostics;

namespace Almox.API.Pipeline.Handlers;

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
                context.Response.StatusCode = (int)errorSummary.ExceptionCode;

                var errorResponse = JsonSerializer.Serialize(new
                {
                    statusCode = errorSummary.ExceptionCode,
                    message = errorSummary.Message,
                    details = errorSummary.Details
                });
                await context.Response.WriteAsync(errorResponse);
            });
        });
    
    private static IExceptionDataExtractor ResolveExtractor(
        Exception error, IServiceProvider services)
    {
        var errorType = error.GetType();
        var extractorType = typeof(IExceptionDataExtractor<>).MakeGenericType(errorType);

        return (IExceptionDataExtractor?) services.GetService(extractorType)
            ?? new DefaultExceptionDataExtractor();
    }
}