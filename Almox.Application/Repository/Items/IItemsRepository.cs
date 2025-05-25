using Almox.Domain.Entities;

namespace Almox.Application.Repository.Items;

public record ItemFilters(
    string? Name,
    string? CategoryName
);

public interface IItemsRepository
    : IBaseRepository<Item, ItemFilters>;