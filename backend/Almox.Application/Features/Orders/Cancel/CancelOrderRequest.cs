using MediatR;

namespace Almox.Application.Features.Orders.Cancel;

public sealed record CancelOrderRequest(
    Guid OrderId,
    string Observations
) : IRequest<CancelOrderResponse>;