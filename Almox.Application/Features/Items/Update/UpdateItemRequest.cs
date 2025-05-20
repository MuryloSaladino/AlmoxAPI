using MediatR;

namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemRequest(
    Guid Id,
    UpdateItemRequestProps Props
) : IRequest<UpdateItemResponse>;

public sealed record UpdateItemRequestProps(
    string Name,
    int Quantity,
    string? ImageUrl
);