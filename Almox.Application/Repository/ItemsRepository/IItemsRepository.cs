using Almox.Domain.Entities;

namespace Almox.Application.Repository.ItemsRepository;

public interface IItemsRepository : IBaseRepository<Item> 
{
    Task<List<Item>> GetWithFilters(IItemsQueryFilters filters, CancellationToken cancellationToken);
}