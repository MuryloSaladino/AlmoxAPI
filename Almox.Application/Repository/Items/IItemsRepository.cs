using Almox.Domain.Entities;

namespace Almox.Application.Repository.Items;

public interface IItemsRepository : IBaseRepository<Item> 
{
    Task<List<Item>> GetWithFilters(
        ItemsQueryFilters filters, CancellationToken cancellationToken);
}