using MediatR;

namespace Almox.Application.Features.Items.Create;

public sealed record CreateItemRequest(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    List<Guid> CategoryIds
) : IRequest<CreateItemResponse>;