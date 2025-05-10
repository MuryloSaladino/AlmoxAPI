namespace Almox.Domain.Entities;

public class Department : BaseEntity
{
    public required string Name { get; set; }
    
    public List<User> Users { get; } = [];
}
