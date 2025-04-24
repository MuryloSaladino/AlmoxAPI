using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class DeliveryItem : BaseEntity
{
    public required Item Item { get; set; }
    public required Delivery Delivery { get; set; }
    public required int Quantity { get; set; }
}
