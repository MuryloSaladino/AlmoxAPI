using Almox.Domain.Common.Enums;

namespace Almox.Application.Repository.Deliveries;

public record DeliveriesQueryFilters(
    DeliveryStatus? Status,
    DateTime? Start,
    DateTime? End
);