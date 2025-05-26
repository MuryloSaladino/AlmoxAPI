using MediatR;

namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemRequest(
    Guid Id,
    UpdateItemRequestProps Props
) : IRequest<UpdateItemResponse>;

public sealed record UpdateItemRequestProps(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    List<Guid> CategoryIds
);