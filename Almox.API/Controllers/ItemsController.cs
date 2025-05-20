using Almox.API.Enums;
using Almox.Application.Features.Items.Categorize;
using Almox.Application.Features.Items.Create;
using Almox.Application.Features.Items.Delete;
using Almox.Application.Features.Items.Find;
using Almox.Application.Features.Items.Update;
using Almox.Application.Features.Items.UpdateImage;
using Almox.Application.Repository.ItemsRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Items)]
public class ItemsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateItemResponse>> Create(
        CreateItemRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Items, response);
    }

    [HttpDelete, Route("{itemId}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid itemId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteItemRequest(itemId), cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<List<FindItemsResponse>>> Find(
        [FromQuery] string? name,
        [FromQuery] string? category,
        CancellationToken cancellationToken)
    {
        var filters = new ItemsQueryFilters(name, category);
        var response = await mediator.Send(new FindItemsRequest(filters), cancellationToken);
        return Ok(response);
    }

    [HttpPatch, Route("{itemId}")]
    public async Task<ActionResult<UpdateItemResponse>> Update(
        [FromRoute] Guid itemId,
        [FromBody] UpdateItemRequestProps body,
        CancellationToken cancellationToken)
    {
        var request = new UpdateItemRequest(itemId, body);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost, Route("{itemId}/categories/{categoryId}")]
    public async Task<ActionResult<CategorizeItemResponse>> Categorize(
        [FromRoute] Guid itemId,
        [FromRoute] Guid categoryId,
        CancellationToken cancellationToken)
    {
        var request = new CategorizeItemRequest(itemId, categoryId);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPatch, Route("{itemId}/image")]
    public async Task<ActionResult<UpdateImageItemResponse>> Save(
        [FromRoute] Guid itemId,
        [FromForm] IFormFile file,
        CancellationToken cancellationToken)
    {
        await using var stream = file.OpenReadStream();
        var request = new UpdateImageItemRequest(itemId, stream, file.FileName);
        var response = await mediator.Send(request, cancellationToken);
        return Created($"{APIRoutes.Images}/uploads", response);
    }
}