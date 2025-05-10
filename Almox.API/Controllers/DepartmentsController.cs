using Almox.API.Enums;
using Almox.API.Middlewares.Authenticate;
using Almox.API.Middlewares.AuthorizeAdmin;
using Almox.Application.Features.Departments.Create;
using Almox.Application.Features.Departments.Delete;
using Almox.Application.Features.Departments.Find;
using Almox.Application.Features.Departments.FindById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(RouteConstants.Departments)]
[Authenticate, AuthorizeAdmin]
public class DepartmentsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateDepartmentResponse>> Create(
        CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(RouteConstants.Departments, response);
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteDepartmentRequest(id), cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<FindDepartmentsResponse>> Find(
        [FromQuery] string? name, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindDepartmentsRequest(name), cancellationToken);
        return Ok(response);
    }

    [HttpGet, Route("{id}")]
    public async Task<ActionResult<FindDepartmentByIdResponse>> FindById(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindDepartmentByIdRequest(id), cancellationToken);
        return Ok(response);
    }
}
