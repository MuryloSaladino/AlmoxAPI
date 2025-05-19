using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Orders.Find;

public sealed record FindOrdersResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    OrderPriority Priority,
    string? Observations,
    OrderStatus Status
);