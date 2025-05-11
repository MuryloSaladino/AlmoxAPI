using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Requests.Create;

public sealed record CreateRequestResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    int Priority,
    string Observations,
    RequestStatus Status,
    List<RequestItem> RequestItems
);