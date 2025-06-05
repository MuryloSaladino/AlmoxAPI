using Almox.Domain.Entities;

namespace Almox.Application.Repository.Categories;

public record CategoryFilters : PaginatedFilter
{
    public string? Name { get; init; }
}

public interface ICategoriesRepository
    : IBaseRepository<Category, CategoryFilters>;