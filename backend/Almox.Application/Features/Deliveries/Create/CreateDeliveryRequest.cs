using MediatR;

namespace Almox.Application.Features.Deliveries.Create;

public sealed record CreateDeliveryRequest(
    string Supplier,
    DateTime ExpectedDate,
    string? Observations,
    List<CreateDeliveryItemRequest> Items
) : IRequest<CreateDeliveryResponse>;

public sealed record CreateDeliveryItemRequest(
    Guid ItemId,
    int Quantity,
    decimal SupplierPrice
);