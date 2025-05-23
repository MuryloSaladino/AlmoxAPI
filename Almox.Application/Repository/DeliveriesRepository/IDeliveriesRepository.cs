using Almox.Domain.Entities;

namespace Almox.Application.Repository.DeliveriesRepository;

public interface IDeliveriesRepository
    : IBaseRepository<Delivery>
{
    Task<List<Delivery>> GetWithFilters(
        DeliveriesQueryFilters filters, CancellationToken cancellationToken);       
}