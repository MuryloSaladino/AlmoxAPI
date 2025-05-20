using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Orders.Start;

public sealed record StartOrderResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    OrderPriority Priority,
    string Observations,
    OrderStatus Status,
    List<StartOrderItemPresenter> OrderItems
);

public class StartOrderItemPresenter
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } 
    public int? Quantity { get; set; }
    public string? ImageUrl { get; set; }
}