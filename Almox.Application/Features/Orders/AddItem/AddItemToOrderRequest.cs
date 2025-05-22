using MediatR;

namespace Almox.Application.Features.Orders.AddItem;

public sealed record AddItemToOrderRequest(
    Guid ItemId,
    AddItemToOrderRequestProps Props
) : IRequest<AddItemToOrderResponse>;

public sealed record AddItemToOrderRequestProps(
    int Quantity
);