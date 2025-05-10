namespace Almox.Domain.Entities;

public class ActionLog : BaseEntity
{
    public required Guid UserId { get; set; }
    public required User User { get; set; }
    
    public required string Description { get; set; }
}