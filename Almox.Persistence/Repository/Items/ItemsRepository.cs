using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Items;

public class ItemsRepository(
    AlmoxContext context
) : BaseRepository<Item>(context), IItemsRepository
{
    public async Task<PaginatedResult<Item>> GetAll(
        ItemFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Item>()
            .Where(i => i.DeletedAt == null)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.Name))
            query = query.Where(i =>
                EF.Functions.ILike(i.Name, $"%{filters.Name}%"));

        if (!string.IsNullOrWhiteSpace(filters.CategoryName))
            query = query.Where(i =>
                i.Categories.Any(c => EF.Functions.ILike(c.Name, $"%{filters.CategoryName}%")));

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .OrderByDescending(e => e.CreatedAt)
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);

        return new(filters.Page, filters.PageSize, maxPage, results);
    }
}