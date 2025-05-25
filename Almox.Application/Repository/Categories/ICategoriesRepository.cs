using Almox.Domain.Entities;

namespace Almox.Application.Repository.Categories;

public record CategoryFilters(
    List<Guid> CategoryIds
);

public interface ICategoriesRepository
    : IBaseRepository<Category, CategoryFilters>;