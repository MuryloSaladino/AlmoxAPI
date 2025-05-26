using Almox.API.Enums;
using Almox.Application.Features.Orders.GetAll;
using Almox.Application.Features.Orders.Get;
using Almox.Application.Features.Orders.UpdateStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Orders.Create;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Orders)]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(
        CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Orders, response);
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

    [HttpPatch]
    public async Task<ActionResult<UpdateOrderStatusResponse>> UpdateStatus(
        UpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}