using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Repository.Deliveries;

public record DeliveryFilters : PaginatedFilter
{
    public DeliveryStatus? Status { get; init; }
    public DateTime? Start { get; init; }
    public DateTime? End { get; init; }
}

public interface IDeliveriesRepository
    : IBaseRepository<Delivery, DeliveryFilters>
{
    Task<int> CountPending(CancellationToken cancellationToken);
}