using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Requests.FindById;

public sealed record FindRequestByIdResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    RequestPriority Priority,
    string? Observations,
    RequestStatus Status,
    List<FindRequestByIdItemPresenter> RequestItems
);

public class FindRequestByIdItemPresenter
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } 
    public int? Quantity { get; set; }
}