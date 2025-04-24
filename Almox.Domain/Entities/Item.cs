using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class Item : BaseEntity
{
    public required string Name { get; set; }
    public required Int Quantity { get; set; }
}
