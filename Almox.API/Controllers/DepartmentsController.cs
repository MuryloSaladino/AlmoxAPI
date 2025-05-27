using Almox.API.Enums;
using Almox.Application.Features.Departments.Create;
using Almox.Application.Features.Departments.Delete;
using Almox.Application.Features.Departments.GetAll;
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
        var request = new DeleteDepartmentRequest(departmentId);
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<GetAllDepartmentsResponse>> GetAll(
        [FromQuery] GetAllDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
