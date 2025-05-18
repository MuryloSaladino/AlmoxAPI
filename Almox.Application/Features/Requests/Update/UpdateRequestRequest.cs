using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Requests.Update;

public sealed record UpdateRequestRequest(
    Guid Id,
    UpdateRequestRequestPayload Body
) : IRequest<UpdateRequestResponse>;

public record UpdateRequestRequestPayload(
    RequestPriority Priority,
    string? Observations
);