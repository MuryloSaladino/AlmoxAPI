using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.API.Middlewares.Authenticate;
using Almox.Application.Features.Users.Register;
using Almox.Application.Features.Users.FindById;
using Almox.Application.Features.Users.Promote;
using Almox.API.Enums;
using Almox.Application.Features.Users.Find;
using Almox.Application.Repository.UsersRepository;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Users)]
[Authenticate]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> Register(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    [HttpGet, Route("{id}")]
    public async Task<ActionResult<FindUserByIdResponse>> FindById(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserByIdRequest(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindUsersResponse>>> Find(
        [FromQuery] string? username,
        [FromQuery] string? email,
        CancellationToken cancellationToken)
    {
        var filters = new UsersQueryFilters(username, email);
        var response = await mediator.Send(new FindUsersRequest(filters), cancellationToken);
        return Ok(response);
    }

    [HttpPatch, Route("promote/{id}")]
    public async Task<ActionResult<PromoteUserResponse>> Promote(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new PromoteUserRequest(id), cancellationToken);
        return Ok(response);
    }
}