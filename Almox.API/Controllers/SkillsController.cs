using MediatR;
using Microsoft.AspNetCore.Mvc;
using Almox.API.Middlewares.Authenticate;
using Almox.Application.Features.Almox.Create;
using Almox.Application.Features.Almox.Delete;
using Almox.Application.Features.Almox.Edit;

namespace Almox.API.Controllers;

[ApiController]
[Route("/Almox")]
[Authenticate]
public class AlmoxController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateSkillResponse>> CreateSkill(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created("/Almox", response);
    }

    [HttpPut, Route("{id}")]
    public async Task<ActionResult<EditSkillResponse>> EditSkill(
        [FromRoute] string id, EditSkillRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult> DeleteSkill(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteSkillRequest(id), cancellationToken);
        return NoContent();
    }
}