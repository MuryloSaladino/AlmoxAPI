using MediatR;

namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemRequest(
    string Id,
    string? Name,
    int? Quantity
) : IRequest<UpdateItemResponse>;