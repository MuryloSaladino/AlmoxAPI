using Almox.API.Enums;
using Almox.Application.Features.Orders.AddItem;
using Almox.Application.Features.Orders.Start;
using Almox.Application.Features.Orders.Find;
using Almox.Application.Features.Orders.FindById;
using Almox.Application.Features.Orders.UpdateStatus;
using Almox.Application.Repository.OrdersRepository;
using Almox.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Orders.Update;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Orders)]
public class OrdersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<StartOrderResponse>> Start(
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new StartOrderRequest(), cancellationToken);
        return Created(APIRoutes.Orders, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindOrdersResponse>>> Find(
        [FromQuery] Guid? userId,
        [FromQuery] OrderStatus? status,
        CancellationToken cancellationToken)
    {
        var filters = new OrdersQueryFilters(userId, status);
        var response = await mediator.Send(new FindOrdersRequest(filters), cancellationToken);
        return Ok(response);
    }

    [HttpGet, Route("{orderId}")]
    public async Task<ActionResult<FindOrderByIdResponse>> FindById(
        [FromRoute] Guid orderId,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindOrderByIdRequest(orderId), cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("{orderId}/items/{itemId}")]
    public async Task<ActionResult<AddItemToOrderResponse>> AddItem(
        [FromRoute] Guid orderId,
        [FromRoute] Guid itemId,
        [FromBody] AddItemToOrderRequestProps body,
        CancellationToken cancellationToken)
    {
        var request = new AddItemToOrderRequest(orderId, itemId, body);
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Orders + "/{orderId}/items/{itemId}", response);
    }

    [HttpPut, Route("{orderId}")]
    public async Task<ActionResult<UpdateOrderResponse>> Update(
        [FromRoute] Guid orderId,
        UpdateOrderRequestProps body,
        CancellationToken cancellationToken)
    {
        var request = new UpdateOrderRequest(orderId, body);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("{orderId}/status/{status}")]
    public async Task<ActionResult<UpdateOrderStatusResponse>> UpdateStatus(
        [FromRoute] Guid orderId,
        [FromRoute] OrderStatus status,
        CancellationToken cancellationToken)
    {
        var request = new UpdateOrderStatusRequest(orderId, status);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}