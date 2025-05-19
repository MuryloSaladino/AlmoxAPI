using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Orders.Update;

public sealed record UpdateOrderRequest(
    Guid Id,
    UpdateOrderRequestProps Props
) : IRequest<UpdateOrderResponse>;

public record UpdateOrderRequestProps(
    OrderPriority Priority,
    string? Observations
);