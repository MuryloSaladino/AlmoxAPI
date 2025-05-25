using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class DeliveryStatusUpdate
{
    public required Guid DeliveryId { get; set; }
    public required Guid UpdatedById { get; set; }

    public DateTime UpdatedAt { get; } = DateTime.UtcNow;
    public required DeliveryStatus Status { get; set; }
    public string? Observations { get; set; } = null;
}