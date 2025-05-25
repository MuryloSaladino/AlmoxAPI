using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class DeliveryHistory : BaseEntity
{
    public required Guid DeliveryId { get; set; }

    public required User UpdatedBy { get; set; }
    public required Guid UpdatedById { get; set; }

    public required DeliveryStatus Status { get; set; }
}