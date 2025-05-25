namespace Almox.Domain.Entities;

public class OrderItem
{
    public required Guid OrderId { get; set; }
    public required Guid ItemId { get; set; }

    public required int Quantity { get; set; }
}