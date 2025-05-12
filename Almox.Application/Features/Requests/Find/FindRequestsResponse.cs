using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Requests.Find;

public sealed record FindRequestsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    int Priority,
    string? Observations,
    RequestStatus Status
);