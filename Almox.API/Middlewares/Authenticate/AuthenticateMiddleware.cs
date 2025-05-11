using System.Text.Json;
using Almox.Application.Common.Session;
using Almox.Application.Contracts;
using Almox.Domain.Common.Messages;

namespace Almox.API.Middlewares.Authenticate;

public class AuthenticateMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        var requiresAuthentication = endpoint?.Metadata.GetMetadata<AuthenticateAttribute>() != null;
        
        if (!requiresAuthentication)
        {
            await _next(context);
            return;
        }

        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            string message = JsonSerializer.Serialize(new { message = ExceptionMessages.Unauthorized.MissingToken });
            await context.Response.WriteAsync(message);
            return;
        }

        var token = authHeader["Bearer ".Length..];

        try
        {
            var authService = context.RequestServices.GetRequiredService<IAuthenticator>();
            var scopedSession = context.RequestServices.GetRequiredService<IUserSession>();

            var sessionPayload = authService.ExtractToken(token);
            scopedSession.SetSession(sessionPayload);

            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            string message = JsonSerializer.Serialize(new { message = ExceptionMessages.Unauthorized.Token });
            await context.Response.WriteAsync(message);
        }
    }
}