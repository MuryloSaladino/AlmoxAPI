using Almox.API.Enums;
using Almox.Application.Features.Deliveries.Create;
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
}