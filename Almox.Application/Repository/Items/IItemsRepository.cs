using Almox.Domain.Entities;

namespace Almox.Application.Repository.Items;

public record ItemsQueryFilters(
    string? Name,
    string? CategoryName
);

public interface IItemsRepository
    : IBaseRepository<Item, ItemsQueryFilters>;