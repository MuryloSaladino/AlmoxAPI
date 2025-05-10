using Almox.Domain.Common;
using Almox.Domain.Enums;

namespace Almox.Domain.Entities;

public class Request : BaseEntity
{
    public required Guid UserId { get; set; }
    public required User User { get; set; }

    public List<RequestItem> RequestItems { get; } = [];

    public int Priority { get; set; }
    public string? Observations { get; set; } = null;
    public Status Status { get; set; } = Status.DRAFT;
}
