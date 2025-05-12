using Almox.API.Enums;
using Almox.API.Middlewares.Authenticate;
using Almox.Application.Features.Requests.AddItem;
using Almox.Application.Features.Requests.Create;
using Almox.Application.Features.Requests.Find;
using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Requests)]
[Authenticate]
public class RequestsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateRequestResponse>> Create(
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new CreateRequestRequest(), cancellationToken);
        return Created(APIRoutes.Requests, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindRequestsResponse>>> Find(
        [FromQuery] Guid? userId,
        [FromQuery] RequestStatus? status,
        CancellationToken cancellationToken)
    {
        var filters = new RequestsQueryFilters(userId, status);
        var response = await mediator.Send(new FindRequestsRequest(filters), cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("{requestId}/items/{itemId}")]
    public async Task<ActionResult<AddItemToRequestResponse>> AddItem(
        [FromRoute] Guid requestId,
        [FromRoute] Guid itemId,
        [FromBody] AddItemToRequestRequestBody body,
        CancellationToken cancellationToken)
    {
        var request = new AddItemToRequestRequest(requestId, itemId, body);
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Requests + "/{requestId}/items/{itemId}", response);
    }
}