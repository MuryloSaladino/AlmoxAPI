using Almox.API.Enums;
using Almox.Application.Features.Categories.Create;
using Almox.Application.Features.Categories.Delete;
using Almox.Application.Features.Categories.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Categories)]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateCategoryResponse>> Create(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Categories, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllCategoriesResponse>>> GetAll(
        [FromQuery] GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("{categoryId}")]
    public async Task<ActionResult> Delete(
        Guid categoryId, CancellationToken cancellationToken)
    {
        var request = new DeleteCategoryRequest(categoryId);
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }
}