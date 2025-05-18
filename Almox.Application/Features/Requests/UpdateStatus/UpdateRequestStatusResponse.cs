using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Requests.UpdateStatus;

public sealed record UpdateRequestStatusResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    RequestPriority Priority,
    string? Observations,
    RequestStatus Status
);
