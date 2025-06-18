using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Categories;

public class CategoriesRepository(
    AlmoxContext context
) : BaseRepository<Category>(context), ICategoriesRepository
{
    public async Task<PaginatedResult<Category>> GetAll(
        CategoryFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Category>()
            .AsQueryable()
            .Where(e => e.DeletedAt == null);

        if (filters.Name is string name)
            query = query.Where(d => EF.Functions.ILike(d.Name, $"%{filters.Name}%"));

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .OrderBy(d => d.Name)
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);

        return new(filters.Page, filters.PageSize, maxPage, results);
    }
}
