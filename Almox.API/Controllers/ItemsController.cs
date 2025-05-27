using Almox.API.Enums;
using Almox.Application.Features.Items.Create;
using Almox.Application.Features.Items.Delete;
using Almox.Application.Features.Items.GetAll;
using Almox.Application.Features.Items.Update;
using Almox.Application.Features.Items.UpdateImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almox.API.Controllers;

[ApiController]
[Route(APIRoutes.Items)]
public class ItemsController(IMediator mediator) : ControllerBase
{
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
        var request = new DeleteItemRequest(itemId);
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllItemsResponse>>> GetAll(
        [FromQuery] GetAllItemsRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateItemResponse>> Update(
        UpdateItemRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut, Route("{itemId}/image")]
    public async Task<ActionResult<UpdateImageItemResponse>> UpdateImage(
        [FromRoute] Guid itemId,
        [FromForm] IFormFile file,
        CancellationToken cancellationToken)
    {
        await using var stream = file.OpenReadStream();
        var request = new UpdateImageItemRequest(itemId, stream, file.FileName);
        var response = await mediator.Send(request, cancellationToken);
        return Created($"{APIRoutes.Items}/{{itemId}}/image", response);
    }
}