using MediatR;

namespace Almox.Application.Features.Items.Delete;

public sealed record DeleteItemRequest(
    Guid ItemId
) : IRequest<DeleteItemResponse>;
