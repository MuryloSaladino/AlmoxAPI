using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Users.Register;
using Almox.Application.Features.Users.Get;
using Almox.API.Enums;
using Almox.Application.Features.Users.GetAll;
using Almox.Application.Repository.Users;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Users)]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<RegisterUserResponse>> Register(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    [HttpGet, Route("{userId}")]
    public async Task<ActionResult<GetUserResponse>> Get(
        [FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest(userId);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllUsersResponse>>> GetAll(
        [FromQuery] UserFilters filters, CancellationToken cancellationToken)
    {
        var request = new GetAllUsersRequest(filters);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}