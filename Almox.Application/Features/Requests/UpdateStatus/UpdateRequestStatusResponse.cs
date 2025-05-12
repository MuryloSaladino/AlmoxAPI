using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Requests.UpdateStatus;

public sealed record UpdateRequestStatusResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    int Priority,
    string? Observations,
    RequestStatus Status,
    List<UpdateRequestStatusResponseItem> RequestItems
);

public class UpdateRequestStatusResponseItem
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } 
    public int? Quantity { get; set; }
}
