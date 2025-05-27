using MediatR;

namespace Almox.Application.Features.Deliveries.Advance;

public sealed record AdvanceDeliveryRequest(
    Guid DeliveryId,
    string? Observations
) : IRequest<AdvanceDeliveryResponse>;
