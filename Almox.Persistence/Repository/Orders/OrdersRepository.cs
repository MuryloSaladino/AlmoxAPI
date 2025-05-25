using Almox.Application.Repository.Orders;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Orders;

public class OrdersRepository(
    AlmoxContext almoxContext
) : BaseRepository<Order>(almoxContext), IOrdersRepository
{
    public async Task<List<Order>> GetWithFilters(
        OrdersQueryFilters filters, CancellationToken cancellationToken)
    {
        var query = dbSet
            .Where(r => r.DeletedAt == null)
            .Where(r => r.Status != null)
            .OrderByDescending(o => o.Priority)
            .AsQueryable();

        if (filters.UserId is not null)
            query = query.Where(r => r.UserId == filters.UserId);

        if (filters.Status is not null)
            query = query.Where(r => r.Status == filters.Status);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetWithItems(Guid id, CancellationToken cancellationToken)
        => await dbSet
            .Where(o => o.DeletedAt == null)
            .Where(o => o.Id == id)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
            .FirstOrDefaultAsync(cancellationToken);
            
    public async Task<Order?> GetUserCartOrder(Guid userId, CancellationToken cancellationToken)
        => await dbSet
            .Where(o => o.DeletedAt == null)
            .Where(o => o.UserId == userId)
            .Where(o => o.Status == null)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
            .FirstOrDefaultAsync(cancellationToken);
}
