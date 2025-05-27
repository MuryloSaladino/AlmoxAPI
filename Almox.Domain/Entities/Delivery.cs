using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class Delivery : BaseEntity
{
    public required string Supplier { get; set; }
    public required string Tracking { get; set; }
    public required DateTime ExpectedDate { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Booked;

    public List<DeliveryItem> DeliveryItems { get; set; } = [];
    public List<DeliveryStatusUpdate> StatusUpdates { get; } = [];
}
