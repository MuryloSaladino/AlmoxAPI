using MediatR;

namespace Almox.Application.Features.Orders.Advance;

public sealed record AdvanceOrderRequest(
    Guid OrderId,
    string? Observations
) : IRequest<AdvanceOrderResponse>;