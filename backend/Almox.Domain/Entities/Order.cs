using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class Order : BaseEntity
{
    public required Guid UserId { get; set; }

    public required string Tracking { get; set; }
    public OrderPriority Priority { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Requested;
    public string? Observations { get; set; } = null;

    public List<OrderItem> OrderItems { get; set; } = [];
    public List<OrderStatusUpdate> StatusUpdates { get; } = [];
}
