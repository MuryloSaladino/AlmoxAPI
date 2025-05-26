using Almox.Application.Repository;
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
    public async Task<PaginatedResult<Order>> GetAll(
        OrderFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Order>()
            .AsQueryable()
            .Where(e => e.DeletedAt == null);

        if (filters.Status is OrderStatus status)
            query = query.Where(r => r.Status == status);

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .OrderByDescending(o => o.Priority)
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);

        return new(filters.Page, filters.PageSize, maxPage, results);
    }

    public async Task<PaginatedResult<Order>> GetAllByUser(
        Guid userId, OrderFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Order>()
            .AsQueryable()
            .Where(e => e.DeletedAt == null)
            .Where(e => e.UserId == userId);

        if (filters.Status is OrderStatus status)
            query = query.Where(r => r.Status == status);

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .OrderByDescending(o => o.Priority)
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);

        return new(filters.Page, filters.PageSize, maxPage, results);
    }

    public Task<Order?> GetUserCartOrder(Guid userId, CancellationToken cancellationToken)
        => context.Set<Order>()
            .Where(o => o.DeletedAt == null)
            .Where(o => o.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);
}
