using MediatR;

namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemRequest(
    string? Name,
    int? Quantity
) : IRequest<UpdateItemResponse>;