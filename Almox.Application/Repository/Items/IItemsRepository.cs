using Almox.Domain.Entities;

namespace Almox.Application.Repository.Items;

public record ItemFilters : PaginatedFilter
{
    public string? Name { get; init; }
    public string? CategoryName { get; init; }
}

public interface IItemsRepository
    : IBaseRepository<Item, ItemFilters>;