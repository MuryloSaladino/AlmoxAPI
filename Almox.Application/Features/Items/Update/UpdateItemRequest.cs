using MediatR;

namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemRequest(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    List<Guid> CategoryIds
) : IRequest<UpdateItemResponse>;
