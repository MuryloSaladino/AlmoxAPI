using MediatR;

namespace Almox.Application.Features.Orders.Get;

public sealed record GetOrderRequest(
    Guid OrderId
) : IRequest<GetOrderResponse>;