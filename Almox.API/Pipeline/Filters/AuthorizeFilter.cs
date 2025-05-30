using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;

namespace Almox.API.Pipeline.Filters;

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
            var requestSession = httpContext.RequestServices.GetRequiredService<IRequestSession>();
            var role = requestSession.GetSessionOrThrow().Role;

            if (authorizeAttribute.Role < role)
                throw AppException.Forbidden(ExceptionMessages.Forbidden.Role);
        }
        catch (AppException e)
        {
            var result = new ContentResult
            {
                Content = JsonSerializer.Serialize(new
                {
                    statusCode = e.Code,
                    message = e.Message,
                    details = e.Details,
                }),
                StatusCode = (int)e.Code,
                ContentType = "application/json"
            };
            context.Result = result;
        }
    }
}
