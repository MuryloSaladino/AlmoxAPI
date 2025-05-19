using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Orders.FindById;

public sealed record FindOrderByIdResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    OrderPriority Priority,
    string? Observations,
    OrderStatus Status,
    List<FindOrderByIdItemPresenter> OrderItems
);

public class FindOrderByIdItemPresenter
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } 
    public int? Quantity { get; set; }
}