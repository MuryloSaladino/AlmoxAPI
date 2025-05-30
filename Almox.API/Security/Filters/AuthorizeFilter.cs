using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using Almox.Application.Contracts;
using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;

namespace Almox.API.Security.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute(UserRole role = UserRole.Employee) : Attribute
{
    public UserRole Role { get; } = role;
}

public class AuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizeAttribute = context.ActionDescriptor.EndpointMetadata
            .OfType<AuthorizeAttribute>()
            .FirstOrDefault();

        if (authorizeAttribute is null)
            return;

        try
        {
            var httpContext = context.HttpContext;
            var token = GetTokenFromContext(httpContext) ?? throw AppException.Unauthorized();

            var authService = httpContext.RequestServices.GetRequiredService<IAuthenticator>();
            var scopedSession = httpContext.RequestServices.GetRequiredService<IRequestSession>();

            var sessionPayload = authService.ExtractToken(token);

            if (authorizeAttribute.Role < sessionPayload.Role)
                throw AppException.Forbidden(ExceptionMessages.Forbidden.Role);

            scopedSession.SetSession(sessionPayload);
        }
        catch (AppException e)
        {
            var result = new ContentResult
            {
                Content = JsonSerializer.Serialize(new { message = e.Message }),
                StatusCode = (int)e.Code,
                ContentType = "application/json"
            };
            context.Result = result;
        }
        catch (Exception)
        {
            var result = new ContentResult
            {
                Content = JsonSerializer.Serialize(new { message = ExceptionMessages.InternalServerError.Default }),
                StatusCode = 500,
                ContentType = "application/json"
            };
            context.Result = result;
        }
    }

    private static string? GetTokenFromContext(HttpContext context)
    {
        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();

        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            return authHeader["Bearer ".Length..];

        return context.Request.Cookies["accessToken"];
    }
}
