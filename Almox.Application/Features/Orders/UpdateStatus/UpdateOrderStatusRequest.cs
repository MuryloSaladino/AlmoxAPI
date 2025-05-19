using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Orders.UpdateStatus;

public sealed record UpdateOrderStatusRequest(
    Guid Id,
    OrderStatus Status
) : IRequest<UpdateOrderStatusResponse>;