using MediatR;

namespace Almox.Application.Features.Orders.RemoveItem;

public sealed record RemoveItemFromOrderRequest(
    Guid ItemId
) : IRequest<RemoveItemFromOrderResponse>;