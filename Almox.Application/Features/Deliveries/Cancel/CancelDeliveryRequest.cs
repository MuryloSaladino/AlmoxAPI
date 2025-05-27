using MediatR;

namespace Almox.Application.Features.Deliveries.Cancel;

public sealed record CancelDeliveryRequest(
    Guid DeliveryId,
    string Observations
) : IRequest<CancelDeliveryResponse>;