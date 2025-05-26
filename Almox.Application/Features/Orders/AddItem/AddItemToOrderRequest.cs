using MediatR;

namespace Almox.Application.Features.Orders.AddItem;

public sealed record AddItemToOrderRequest(
    Guid ItemId,
    int Quantity
) : IRequest<AddItemToOrderResponse>;
