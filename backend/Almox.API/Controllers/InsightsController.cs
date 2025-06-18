using Almox.API.Constants;
using Almox.API.Pipeline.Filters;
using Almox.Application.Features.Insights.Admin;
using Almox.Application.Features.Insights.Inventory;
using Almox.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController, Route(APIRoutes.Insights), Authorize(UserRole.Staff)]
public class InsightsController(IMediator mediator) : ControllerBase
{
    [HttpGet, Route("admin")]
    public async Task<ActionResult<InsightsAdminResponse>> Admin(
        [FromQuery] InsightsAdminRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet, Route("inventory")]
    public async Task<ActionResult<InsightsInventoryResponse>> Inventory(
        [FromQuery] InsightsInventoryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}