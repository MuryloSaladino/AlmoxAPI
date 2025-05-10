namespace Almox.Domain.Entities;

public class RequestItem
{
    public required Guid ItemId { get; set; }
    public required Item Item { get; set; }

    public required Guid RequestId { get; set; }
    public required Request Request { get; set; }

    public required int Quantity { get; set; }
    public int FulfilledQuantity { get; set; } = 0;
}