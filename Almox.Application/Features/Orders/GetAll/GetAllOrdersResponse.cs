using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Orders.GetAll;

public sealed record GetAllOrdersResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    OrderPriority Priority,
    string Tracking,
    OrderStatus Status,
    string? Observations,
    List<OrderItem> OrderItems,
    List<OrderStatusUpdate> StatusUpdates
);