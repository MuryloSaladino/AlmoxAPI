using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Orders.UpdateStatus;

public sealed record UpdateOrderStatusResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    OrderPriority Priority,
    string? Observations,
    OrderStatus Status
);
