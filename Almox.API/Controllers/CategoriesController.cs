using Almox.API.Enums;
using Almox.API.Middlewares.Authenticate;
using Almox.API.Middlewares.AuthorizeAdmin;
using Almox.Application.Features.Categories.Create;
using Almox.Application.Features.Categories.Delete;
using Almox.Application.Features.Categories.Find;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(RouteConstants.Categories)]
[Authenticate]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    [AuthorizeAdmin]
    public async Task<ActionResult<CreateCategoryResponse>> Create(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(RouteConstants.Categories, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindCategoriesResponse>>> Find(
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindCategoriesRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("{id}")]
    [AuthorizeAdmin]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteCategoryRequest(id), cancellationToken);
        return NoContent();
    }
}