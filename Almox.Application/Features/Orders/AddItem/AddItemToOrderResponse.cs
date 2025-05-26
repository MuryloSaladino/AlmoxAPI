namespace Almox.Application.Features.Orders.AddItem;

public sealed record AddItemToOrderResponse(
    Guid OrderId,
    Guid ItemId,
    int Quantity,
    decimal Price
);