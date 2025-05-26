using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Deliveries;

public class DeliveriesRepository(
    AlmoxContext context
) : BaseRepository<Delivery>(context), IDeliveriesRepository
{
    public async Task<PaginatedResult<Delivery>> GetAll(
        DeliveryFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Delivery>()
            .Where(d => d.DeletedAt == null)
            .AsQueryable();

        if (filters.Status is DeliveryStatus statusFilter)
            query = query.Where(d => d.Status == statusFilter);
            
        if (filters.Start is DateTime startDateFilter)
            query = query.Where(d => d.ExpectedDate > startDateFilter);

        if (filters.End is DateTime endDateFilter)
            query = query.Where(d => d.ExpectedDate < endDateFilter);

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);
        
        return new(filters.Page, filters.PageSize, maxPage, results);
    }
}
