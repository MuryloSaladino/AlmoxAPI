using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Orders.Create;

public sealed record CreateOrderRequest(
    OrderPriority Priority,
    string? Observations,
    List<CreateOrderItemRequest> OrderedItems
) : IRequest<CreateOrderResponse>;

public sealed record CreateOrderItemRequest(
    Guid ItemId,
    int Quantity
);