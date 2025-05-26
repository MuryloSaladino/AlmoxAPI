using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Orders.UpdateStatus;

public sealed record UpdateOrderStatusRequest(
    Guid OrderId,
    OrderStatus Status,
    string? Observations
) : IRequest<UpdateOrderStatusResponse>;