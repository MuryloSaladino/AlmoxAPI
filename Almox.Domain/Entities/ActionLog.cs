using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class ActionLog : BaseEntity
{
    public required User User { get; set; }
    public required string Description { get; set; }
}