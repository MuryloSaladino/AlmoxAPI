using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Users.Register;
using Almox.Application.Features.Users.Get;
using Almox.API.Constants;
using Almox.Application.Features.Users.GetAll;
using Almox.API.Pipeline.Filters;
using Almox.Domain.Common.Enums;
using Almox.Application.Features.Users.Count;

namespace Almox.API.Controllers;

[ApiController, Route(APIRoutes.Users)]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost, Authorize(UserRole.Admin)]
    public async Task<ActionResult<RegisterUserResponse>> Register(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }
    
    [HttpGet, Route("count"), Authorize(UserRole.Staff)]
    public async Task<ActionResult<CountUsersResponse>> Count(
        [FromQuery] CountUsersRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet, Authorize(UserRole.Employee), Route("{userId}")]
    public async Task<ActionResult<GetUserResponse>> Get(
        [FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest(userId);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet, Authorize(UserRole.Employee)]
    public async Task<ActionResult<List<GetAllUsersResponse>>> GetAll(
        [FromQuery] GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}