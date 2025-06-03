using Almox.API.Constants;
using Almox.Application.Features.Insights.Admin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController, Route(APIRoutes.Insights)]
public class InsightsController(IMediator mediator) : ControllerBase
{
    [HttpGet, Route("admin")]
    public async Task<ActionResult<InsightsAdminResponse>> Admin(
        [FromQuery] InsightsAdminRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}