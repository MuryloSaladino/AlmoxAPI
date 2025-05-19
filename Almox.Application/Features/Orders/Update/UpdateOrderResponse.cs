using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Orders.Update;

public sealed record UpdateOrderResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    OrderPriority Priority,
    string? Observations,
    OrderStatus Status,
    List<UpdateOrderStatusItemPresenter> OrderItems
);

public class UpdateOrderStatusItemPresenter
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } 
    public required int Quantity { get; set; }
}
