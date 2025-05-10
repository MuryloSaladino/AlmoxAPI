using MediatR;

namespace Almox.Application.Features.Items.Delete;

public sealed record DeleteItemRequest(
    Guid Id
) : IRequest<DeleteItemResponse>;
