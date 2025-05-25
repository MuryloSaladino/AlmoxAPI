using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Repository.Deliveries;

public record DeliveryFilters(
    DeliveryStatus? Status,
    DateTime? Start,
    DateTime? End
);

public interface IDeliveriesRepository
    : IBaseRepository<Delivery, DeliveryFilters>;