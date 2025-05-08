using MediatR;

namespace Almox.Application.Features.Items.Delete;

public sealed record DeleteItemRequest(
    string Id
) : IRequest<DeleteItemResponse>;
