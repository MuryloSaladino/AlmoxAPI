using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class RequestHistory : BaseEntity
{
    public required Request Request { get; set; }
    public required Guid RequestId { get; set; }

    public required User UpdatedBy { get; set; }
    public required Guid UpdatedById { get; set; }

    public required RequestStatus Status { get; set; }
}