using Almox.Application.Repository.Categories;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Categories;

public class CategoriesRepository(
    AlmoxContext context
) : BaseRepository<Category>(context), ICategoriesRepository
{
    public Task<List<Category>> GetAll(CategoryFilters filters, CancellationToken cancellationToken)
        => context.Set<Category>()
            .Where(c => c.DeletedAt == null)
            .Where(c => filters.CategoryIds.Contains(c.Id))
            .ToListAsync(cancellationToken);
}
