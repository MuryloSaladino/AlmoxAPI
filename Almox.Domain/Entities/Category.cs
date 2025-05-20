namespace Almox.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Color { get; set; }
    
    public List<Item> Items { get; } = [];
}
