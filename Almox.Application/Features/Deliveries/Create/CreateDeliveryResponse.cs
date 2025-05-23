using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Deliveries.Create;

public sealed record CreateDeliveryResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    string? Observations,
    DateTime Date,
    DeliveryStatus Status 
);