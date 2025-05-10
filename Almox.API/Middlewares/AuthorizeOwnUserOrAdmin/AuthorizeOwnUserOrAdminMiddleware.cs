using Almox.Domain.Common;

namespace Almox.API.Middlewares.AuthorizeOwnUserOrAdmin;

public class AuthorizeMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        var authorizationAttr = endpoint?.Metadata.GetMetadata<AuthorizeOwnUserOrAdminAttribute>();
        
        if(authorizationAttr is null)
        {
            await _next(context);
            return;
        }

        var idFromRoute = context.Request.RouteValues[authorizationAttr.RouteIdentifier]?.ToString();

        if (!Guid.TryParse(idFromRoute, out var routeUserId))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("{\"message\": \"Invalid or missing user ID in route.\"}");
            return;
        }

        UserSession session = (UserSession) context.Items["UserSession"]!;
    
        if(!session.IsAdmin && session.Id != routeUserId)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("{\"message\": \"Unauthorized\"}");
            return;
        }
        
        await _next(context);
    }
}