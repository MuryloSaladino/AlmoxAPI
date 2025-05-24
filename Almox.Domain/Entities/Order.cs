using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class Order : BaseEntity
{
    public required Guid UserId { get; set; }
    public required User User { get; set; }

    public List<OrderItem> OrderItems { get; } = [];

    public OrderPriority Priority { get; set; }
    public string? Observations { get; set; } = null;
    public OrderStatus? Status { get; set; } = null;
}
