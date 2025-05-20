using System.Text.Json;
using Almox.Application.Common.Session;
using Almox.Application.Contracts;
using Almox.Domain.Common.Messages;

namespace Almox.API.Middlewares;

public class AuthenticateMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader))
        {
            await next(context);
            return;
        }

        if (!authHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            string message = JsonSerializer.Serialize(new { message = ExceptionMessages.Unauthorized.TokenPrefix });
            await context.Response.WriteAsync(message);
            return;
        }

        var token = authHeader["Bearer ".Length..];

        try
        {
            var authService = context.RequestServices.GetRequiredService<IAuthenticator>();
            var scopedSession = context.RequestServices.GetRequiredService<IRequestSession>();

            var sessionPayload = authService.ExtractToken(token);
            scopedSession.SetSession(sessionPayload);

            await next(context);
        }
        catch(Exception e)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            string message = JsonSerializer.Serialize(new { message = e.Message });
            await context.Response.WriteAsync(message);
        }
    }
}