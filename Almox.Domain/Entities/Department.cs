using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class Department : BaseEntity
{
    public required string Name { get; set; }
}
