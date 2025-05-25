using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class OrderStatusUpdate
{
    public required Guid OrderId { get; set; }
    public required Guid UpdatedById { get; set; }

    public DateTime UpdatedAt { get; } = DateTime.UtcNow;
    public required OrderStatus Status { get; set; }
    public string? Observations { get; set; } = null;
}