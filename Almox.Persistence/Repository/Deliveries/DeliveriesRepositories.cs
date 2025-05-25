using Almox.Application.Repository.Deliveries;
using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Deliveries;

public class DeliveriesRepository(
    AlmoxContext almoxContext
) : BaseRepository<Delivery>(almoxContext), IDeliveriesRepository
{
    public Task<List<Delivery>> GetWithFilters(
        DeliveriesQueryFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Delivery>()
            .Where(d => d.DeletedAt == null)
            .AsQueryable();

        if (filters.Status is DeliveryStatus statusFilter)
            query = query.Where(d => d.Status == statusFilter);
        if (filters.Start is DateTime startDateFilter)
            query = query.Where(d => d.Date > startDateFilter);
        if (filters.End is DateTime endDateFilter)
            query = query.Where(d => d.Date < endDateFilter);

        return query.ToListAsync(cancellationToken);
    }
}
