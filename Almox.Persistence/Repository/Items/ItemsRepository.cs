using Almox.Application.Repository.Items;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Items;

public class ItemsRepository(
    AlmoxContext context
) : BaseRepository<Item>(context), IItemsRepository
{
    public Task<List<Item>> GetAll(ItemFilters filters, CancellationToken cancellationToken)
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

        return query.ToListAsync(cancellationToken);
    }
}