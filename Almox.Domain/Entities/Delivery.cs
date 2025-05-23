using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class Delivery : BaseEntity
{
    public required Guid UserId { get; set; }
    public required User User { get; set; }

    public List<DeliveryItem> DeliveryItems { get; } = [];

    public string? Observations { get; set; } = null;
    public required DateTime Date { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Booked;
}
