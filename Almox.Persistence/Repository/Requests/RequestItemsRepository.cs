using Almox.Application.Repository.RequestItemsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Requests;

public class RequestItemsRepository(
    AlmoxContext almoxContext
) : IRequestItemsRepository
{
    private readonly AlmoxContext context = almoxContext;
    private readonly DbSet<RequestItem> dbSet = almoxContext.Set<RequestItem>();

    public void Create(RequestItem requestItem)
        => context.Add(requestItem);

    public void Delete(Guid itemId, Guid requestId)
    {
        var entity = dbSet.Find(itemId, requestId);

        if (entity is not null)
            dbSet.Remove(entity);
    }
}