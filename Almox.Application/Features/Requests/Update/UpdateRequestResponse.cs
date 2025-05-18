using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Requests.Update;

public sealed record UpdateRequestResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    RequestPriority Priority,
    string? Observations,
    RequestStatus Status,
    List<UpdateRequestStatusResponseItem> RequestItems
);

public class UpdateRequestStatusResponseItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } 
    public required int Quantity { get; set; }
}
