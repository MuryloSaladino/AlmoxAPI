using Almox.API.Enums;
using Almox.API.Middlewares.Authenticate;
using Almox.Application.Features.Categories.Create;
using Almox.Application.Features.Categories.Delete;
using Almox.Application.Features.Categories.Find;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Categories)]
[Authenticate]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateCategoryResponse>> Create(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Categories, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindCategoriesResponse>>> Find(
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindCategoriesRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("{categoryId}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid categoryId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteCategoryRequest(categoryId), cancellationToken);
        return NoContent();
    }
}