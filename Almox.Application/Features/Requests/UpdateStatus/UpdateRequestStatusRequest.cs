using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Requests.UpdateStatus;

public sealed record UpdateRequestStatusRequest(
    Guid Id,
    RequestStatus Status
) : IRequest<UpdateRequestStatusResponse>;