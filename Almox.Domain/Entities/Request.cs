using Almox.Domain.Common;
using Almox.Domain.Enums;

namespace Almox.Domain.Entities;

public class Request : BaseEntity
{
    public required User User { get; set; }
    public int Priority { get; set; }
    public string? Observations { get; set; }
    public required Status Status { get; set; }
    public List<RequestItem> RequestItems { get; } = [];
}
