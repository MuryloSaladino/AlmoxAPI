using Almox.Domain.Common.Enums;

namespace Almox.Application.Repository.DeliveriesRepository;

public record DeliveriesQueryFilters(
    DeliveryStatus? Status,
    DateTime? Start,
    DateTime? End
);