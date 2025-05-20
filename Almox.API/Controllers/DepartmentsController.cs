using Almox.API.Enums;
using Almox.Application.Features.Departments.Create;
using Almox.Application.Features.Departments.Delete;
using Almox.Application.Features.Departments.Find;
using Almox.Application.Features.Departments.FindById;
using Almox.Application.Repository.DepartmentsRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Departments)]
public class DepartmentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateDepartmentResponse>> Create(
        CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Departments, response);
    }

    [HttpDelete, Route("{departmentId}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid departmentId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteDepartmentRequest(departmentId), cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<FindDepartmentsResponse>> Find(
        [FromQuery] string? name, CancellationToken cancellationToken)
    {
        var filters = new DepartmentsQueryFilters(name);
        var response = await mediator.Send(new FindDepartmentsRequest(filters), cancellationToken);
        return Ok(response);
    }

    [HttpGet, Route("{departmentId}")]
    public async Task<ActionResult<FindDepartmentByIdResponse>> FindById(
        [FromRoute] Guid departmentId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindDepartmentByIdRequest(departmentId), cancellationToken);
        return Ok(response);
    }
}
