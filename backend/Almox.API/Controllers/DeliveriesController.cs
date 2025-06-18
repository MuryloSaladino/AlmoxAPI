using Almox.API.Constants;
using Almox.API.Pipeline.Filters;
using Almox.Application.Features.Deliveries.Advance;
using Almox.Application.Features.Deliveries.Cancel;
using Almox.Application.Features.Deliveries.Create;
using Almox.Application.Features.Deliveries.GetAll;
using Almox.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController, Route(APIRoutes.Deliveries), Authorize(UserRole.Staff)]
public class DeliveriesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateDeliveryResponse>> Create(
        CreateDeliveryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Deliveries, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllDeliveriesResponse>>> GetAll(
        [FromQuery] GetAllDeliveriesRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("status")]
    public async Task<ActionResult<AdvanceDeliveryResponse>> Advance(
        AdvanceDeliveryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpDelete, Route("status")]
    public async Task<ActionResult<CancelDeliveryResponse>> Cancel(
        CancelDeliveryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}