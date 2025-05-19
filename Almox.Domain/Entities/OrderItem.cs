namespace Almox.Domain.Entities;

public class OrderItem
{
    public required Guid ItemId { get; set; }
    public required Item Item { get; set; }

    public required Guid OrderId { get; set; }
    public required Order Order { get; set; }

    public required int Quantity { get; set; }
    public string? Observations { get; set; } = null;
    public int FulfilledQuantity { get; set; } = 0;
}