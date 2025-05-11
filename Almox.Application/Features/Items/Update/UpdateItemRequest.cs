using MediatR;

namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemRequest(
    Guid Id,
    UpdateItemRequestBody Body
) : IRequest<UpdateItemResponse>;

public sealed record UpdateItemRequestBody(
    string? Name,
    int? Quantity
);