using Almox.API.Enums;
using Almox.Application.Features.Deliveries.Create;
using Almox.Application.Features.Deliveries.GetAll;
using Almox.Application.Repository.Deliveries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Deliveries)]
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
        [FromQuery] DeliveryFilters filters, CancellationToken cancellationToken)
    {
        var request = new GetAllDeliveriesRequest(filters);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}