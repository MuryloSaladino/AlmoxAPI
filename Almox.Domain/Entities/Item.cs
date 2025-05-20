namespace Almox.Domain.Entities;

public class Item : BaseEntity
{
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    
    public List<Category> Categories { get; } = [];
}
