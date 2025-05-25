using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Deliveries.GetAll;

public sealed record GetAllDeliveriesResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Supplier,
    string Tracking,
    DateTime ExpectedDate,
    DeliveryStatus Status,
    List<DeliveryItem> DeliveryItems
);