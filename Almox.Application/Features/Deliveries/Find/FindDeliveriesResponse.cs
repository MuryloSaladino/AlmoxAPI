using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Deliveries.Find;

public sealed record FindDeliveriesResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    DateTime Date,
    DeliveryStatus Status 
);