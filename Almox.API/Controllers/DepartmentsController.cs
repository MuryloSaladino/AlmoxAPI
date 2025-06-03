using Almox.API.Constants;
using Almox.API.Pipeline.Filters;
using Almox.Application.Features.Departments.Count;
using Almox.Application.Features.Departments.Create;
using Almox.Application.Features.Departments.Delete;
using Almox.Application.Features.Departments.GetAll;
using Almox.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController, Route(APIRoutes.Departments)]
public class DepartmentsController(IMediator mediator) : ControllerBase
{
    [HttpPost, Authorize(UserRole.Admin)]
    public async Task<ActionResult<CreateDepartmentResponse>> Create(
        CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Departments, response);
    }

    [HttpDelete, Route("{departmentId}"), Authorize(UserRole.Admin)]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid departmentId, CancellationToken cancellationToken)
    {
        var request = new DeleteDepartmentRequest(departmentId);
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpGet, Route("count"), Authorize(UserRole.Staff)]
    public async Task<ActionResult<CountDepartmentsResponse>> Count(
        [FromQuery] CountDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet, Authorize(UserRole.Staff)]
    public async Task<ActionResult<GetAllDepartmentsResponse>> GetAll(
        [FromQuery] GetAllDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
