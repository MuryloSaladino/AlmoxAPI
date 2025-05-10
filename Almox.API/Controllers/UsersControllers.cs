using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.API.Middlewares.Authenticate;
using Almox.Application.Features.Users.Register;
using Almox.Application.Features.Users.FindById;
using Almox.API.Middlewares.AuthorizeAdmin;
using Almox.Application.Features.Users.Promote;
using Almox.API.Enums;

namespace Almox.API.Controllers;

[ApiController]
[Route(RouteConstants.Users)]
[Authenticate]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]

    public async Task<ActionResult<RegisterUserResponse>> Register(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(RouteConstants.Users, response);
    }

    [HttpGet, Route("{id}")]
    [Authenticate]
    public async Task<ActionResult<FindUserByIdResponse>> FindById(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserByIdRequest(id), cancellationToken);
        return Ok(response);
    }

    [HttpPatch, Route("promote/{id}")]
    [AuthorizeAdmin]
    public async Task<ActionResult<PromoteUserResponse>> PromoteUser(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new PromoteUserRequest(id), cancellationToken);
        return Ok(response);
    }
}