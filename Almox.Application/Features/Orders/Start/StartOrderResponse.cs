using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Orders.Start;

public sealed record StartOrderResponse(
    OrderPriority Priority,
    string? Observations,
    List<OrderItem> OrderItems
);
