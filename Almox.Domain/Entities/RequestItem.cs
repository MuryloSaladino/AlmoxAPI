using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class RequestItem : BaseEntity
{
    public required Item Item { get; set; }
    public required Request Request { get; set; }
    public required int Quantity { get; set; }
    public int FulfilledQuantity { get; set; } = 0;
}
