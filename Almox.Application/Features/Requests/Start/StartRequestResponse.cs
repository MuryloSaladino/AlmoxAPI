using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Requests.Start;

public sealed record StartRequestResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    RequestPriority Priority,
    string Observations,
    RequestStatus Status,
    List<StartRequestItemPresenter> RequestItems
);

public class StartRequestItemPresenter
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } 
    public int? Quantity { get; set; }
}