using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Requests;

public class RequestsRepository(
    AlmoxContext almoxContext
) : BaseRepository<Request>(almoxContext), IRequestsRepository
{
    public async Task<List<Request>> GetWithFilters(RequestsQueryFilters filters, CancellationToken cancellationToken)
    {
        var query = dbSet
            .Where(r => r.DeletedAt == null)
            .AsQueryable();

        if(filters.UserId is not null)
            query = query.Where(r => r.UserId == filters.UserId);
        
        if(filters.Status is not null)
            query = query.Where(r => r.Status == filters.Status);

        return await query.ToListAsync(cancellationToken);
    }
}
