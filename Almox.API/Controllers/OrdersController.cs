using Almox.API.Constants;
using Almox.Application.Features.Orders.GetAll;
using Almox.Application.Features.Orders.Get;
using Almox.Application.Features.Orders.Advance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.Application.Features.Orders.Create;
using Almox.Application.Features.Orders.Cancel;
using Almox.API.Pipeline.Filters;

namespace Almox.API.Controllers;

[ApiController, Route(APIRoutes.Orders), Authorize]
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

    [HttpPost, Route("status")]
    public async Task<ActionResult<AdvanceOrderResponse>> Advance(
        AdvanceOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("status")]
    public async Task<ActionResult<CancelOrderResponse>> Cancel(
        CancelOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);       
    }
}