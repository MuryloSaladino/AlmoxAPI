using Almox.Domain.Entities;
using Almox.Domain.Enums;

namespace Almox.Application.Features.Requests.Create;

public sealed record CreateRequestResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    User User,
    int Priority,
    string Observations,
    Status Status,
    List<RequestItem> RequestItems
);