using MediatR;

namespace Almox.Application.Features.Deliveries.Create;

public sealed record CreateDeliveryRequest(
    string Supplier,
    DateTime ExpectedDate
) : IRequest<CreateDeliveryResponse>;