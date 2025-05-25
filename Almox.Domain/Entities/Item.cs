namespace Almox.Domain.Entities;

public class Item : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int Stock { get; set; }
    public string? ImageUrl { get; set; }
    
    public List<Category> Categories { get; } = [];
}
