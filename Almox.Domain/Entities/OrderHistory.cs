using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class OrderHistory : BaseEntity
{
    public required Order Order { get; set; }
    public required Guid OrderId { get; set; }

    public required User UpdatedBy { get; set; }
    public required Guid UpdatedById { get; set; }

    public required OrderStatus Status { get; set; }
}