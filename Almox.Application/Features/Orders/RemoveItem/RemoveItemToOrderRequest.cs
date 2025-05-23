using MediatR;

namespace Almox.Application.Features.Orders.RemoveItem;

public sealed record RemoveItemToOrderRequest(
    Guid ItemId
) : IRequest<RemoveItemToOrderResponse>;