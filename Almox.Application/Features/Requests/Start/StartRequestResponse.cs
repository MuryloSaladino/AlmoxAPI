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
    List<RequestItem> RequestItems
);