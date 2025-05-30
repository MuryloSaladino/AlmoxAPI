using Almox.API.Constants;
using Almox.API.Pipeline.Filters;
using Almox.Application.Features.Categories.Create;
using Almox.Application.Features.Categories.Delete;
using Almox.Application.Features.Categories.GetAll;
using Almox.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Categories)]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpPost, Authorize(UserRole.Staff)]
    public async Task<ActionResult<CreateCategoryResponse>> Create(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Categories, response);
    }

    [HttpGet, Authorize]
    public async Task<ActionResult<List<GetAllCategoriesResponse>>> GetAll(
        [FromQuery] GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("{categoryId}"), Authorize(UserRole.Staff)]
    public async Task<ActionResult> Delete(
        Guid categoryId, CancellationToken cancellationToken)
    {
        var request = new DeleteCategoryRequest(categoryId);
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }
}