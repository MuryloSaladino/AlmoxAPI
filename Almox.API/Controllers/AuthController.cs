using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Auth.Login;
using Almox.API.Enums;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Auth)]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost, Route("login")]
    public async Task<ActionResult<LoginResponse>> Login(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}