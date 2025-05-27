using MediatR;

namespace Almox.Application.Features.Items.Get;

public sealed record GetItemRequest(
    Guid ItemId
) : IRequest<GetItemResponse>;
