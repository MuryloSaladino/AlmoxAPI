using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class ItemCategory : BaseEntity
{
    public required Item Item { get; set; }
    public required Category Category { get; set; }
}
