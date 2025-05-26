using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Orders;

public class OrdersRepository(
    AlmoxContext context
) : BaseRepository<Order>(context), IOrdersRepository
{
    public Task<List<Order>> GetAll(
        OrderFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Order>()
            .AsQueryable()
            .Where(r => r.DeletedAt == null);

        if (filters.UserId is Guid userId)
            query = query.Where(r => r.UserId == userId);

        if (filters.Status is OrderStatus status)
            query = query.Where(r => r.Status == status);
        else
            query = query.Where(r => r.Status != null);

        query = query.OrderByDescending(o => o.Priority);

        return query.ToListAsync(cancellationToken);
    }

    public Task<Order?> GetUserCartOrder(Guid userId, CancellationToken cancellationToken)
        => context.Set<Order>()
            .Where(o => o.DeletedAt == null)
            .Where(o => o.UserId == userId)
            .Where(o => o.Status == null)
            .FirstOrDefaultAsync(cancellationToken);
}
