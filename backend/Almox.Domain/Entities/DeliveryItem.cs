namespace Almox.Domain.Entities;

public class DeliveryItem
{
    public required Guid DeliveryId { get; set; }
    public required Guid ItemId { get; set; }
    public required Item Item { get; set; }
    
    public required int Quantity { get; set; }
    public required decimal SupplierPrice { get; set; }
}
