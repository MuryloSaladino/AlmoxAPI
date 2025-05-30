using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Auth.Login;
using Almox.API.Enums;
using Almox.Application.Features.Auth.Logout;
using Almox.API.Security.Filters;

namespace Almox.API.Controllers;

[ApiController, Route(APIRoutes.Auth)]
public class AuthController(IMediator mediator) : ControllerBase
{
    private const string AccessToken = "accessToken";
    private const string RefreshToken = "refreshToken";

    [HttpPost, Route("login")]
    public async Task<ActionResult> Login(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        Response.Cookies.Append(AccessToken, response.AccessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = Environment.GetEnvironmentVariable("ENV_MODE") == "prod",
            SameSite = SameSiteMode.Strict,
            Expires = response.ExpiresAt,
        });
        Response.Cookies.Append(RefreshToken, response.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = Environment.GetEnvironmentVariable("ENV_MODE") == "prod",
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(15),
        });

        return Ok();
    }

    [HttpDelete, Route("logout"), Authorize]
    public async Task<ActionResult> Logout(
        [FromQuery] LogoutRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);

        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.UtcNow.AddDays(-1),
        };
        
        Response.Cookies.Append(AccessToken, string.Empty, cookieOptions);
        Response.Cookies.Append(RefreshToken, string.Empty, cookieOptions);

        return NoContent();
    }
}