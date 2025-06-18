using System.Text.Json;
using Almox.API.Constants;
using Almox.Application.Common.Session;
using Almox.Application.Contracts;

namespace Almox.API.Pipeline.Middlewares;

public class AuthMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var accessToken = context.Request.Cookies[Cookies.AccessToken];

        if (accessToken is string token)
        {
            try
            {
                var authService = context.RequestServices.GetRequiredService<IAuthenticator>();
                var scopedSession = context.RequestServices.GetRequiredService<IRequestSession>();
                
                var sessionPayload = authService.ExtractToken(token);
                scopedSession.SetSession(sessionPayload);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                string message = JsonSerializer.Serialize(new { message = e.Message });
                await context.Response.WriteAsync(message);
            }
        }

        await next(context);
    }
}