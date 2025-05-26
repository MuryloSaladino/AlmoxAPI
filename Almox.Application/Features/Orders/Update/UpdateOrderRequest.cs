using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Orders.Update;

public sealed record UpdateOrderRequest(
    Guid Id,
    OrderPriority Priority,
    string? Observations
) : IRequest<UpdateOrderResponse>;
