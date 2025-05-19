using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Requests.Update;

public sealed record UpdateRequestRequest(
    Guid Id,
    UpdateRequestRequestProps Props
) : IRequest<UpdateRequestResponse>;

public record UpdateRequestRequestProps(
    RequestPriority Priority,
    string? Observations
);