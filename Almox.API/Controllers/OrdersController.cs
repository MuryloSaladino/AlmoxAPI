using Almox.API.Enums;
using Almox.Application.Features.Orders.AddItem;
using Almox.Application.Features.Orders.Start;
using Almox.Application.Features.Orders.GetAll;
using Almox.Application.Features.Orders.Get;
using Almox.Application.Features.Orders.UpdateStatus;
using Almox.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Orders.Update;
using Almox.Application.Features.Orders.RemoveItem;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Orders)]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<StartOrderResponse>> Start(
        StartOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllOrdersResponse>>> GetAll(
        [FromQuery] GetAllOrdersRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet, Route("{orderId}")]
    public async Task<ActionResult<GetOrderResponse>> Get(
        [FromRoute] Guid orderId, CancellationToken cancellationToken)
    {
        var request = new GetOrderRequest(orderId);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateOrderResponse>> Update(
        UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateOrderStatusResponse>> UpdateStatus(
        UpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("items")]
    public async Task<ActionResult<AddItemToOrderResponse>> AddItem(
        AddItemToOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Orders + "/items", response);
    }

    [HttpDelete, Route("items/{itemId}")]
    public async Task<ActionResult<AddItemToOrderResponse>> RemoveItem(
        [FromRoute] Guid itemId, CancellationToken cancellationToken)
    {
        var request = new RemoveItemFromOrderRequest(itemId);
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }
}