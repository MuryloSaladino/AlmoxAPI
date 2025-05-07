using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.API.Middlewares.Authenticate;
using Almox.Application.Features.Users.Register;
using Almox.Application.Features.Users.FindById;
using Almox.API.Middlewares.Authorize;
using Almox.Application.Features.Users.Promote;

namespace Almox.API.Controllers;

[ApiController]
[Route("/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created("/users", response);
    }

    [HttpGet, Route("{id}")]
    [Authenticate]
    public async Task<ActionResult<FindUserByIdResponse>> FindUser(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserByIdRequest(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("promote/{id}")]
    [Authenticate, Authorize]
    public async Task<ActionResult<PromoteUserResponse>> PromoteUser(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new PromoteUserRequest(id), cancellationToken);
        return Ok(response);
    }
}