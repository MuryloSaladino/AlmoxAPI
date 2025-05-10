using Almox.Application.Repository.ItemsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Items;

public class ItemsRepository(
    AlmoxContext almoxContext
) : BaseRepository<Item>(almoxContext), IItemsRepository
{
    public async Task<List<Item>> GetWithFilters(IItemsQueryFilters filters, CancellationToken cancellationToken)
    {
        var query = dbSet
            .Include(i => i.Categories)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.Name))
        {
            query = query.Where(i => EF.Functions.ILike(i.Name, $"%{filters.Name}%"));
        }

        if (!string.IsNullOrWhiteSpace(filters.CategoryName))
        {
            query = query.Where(i =>
                i.Categories.Any(c => EF.Functions.ILike(c.Name, $"%{filters.CategoryName}%"))
            );
        }

        return await query.ToListAsync(cancellationToken);
    }
}