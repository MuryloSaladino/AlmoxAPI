using Almox.Application.Repository.DeliveriesRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Deliveries;

public class DeliveryItemsRepository(
    AlmoxContext almoxContext
) : IDeliveryItemsRepository
{
    private readonly AlmoxContext context = almoxContext;
    private readonly DbSet<DeliveryItem> dbSet = almoxContext.Set<DeliveryItem>();

    public void Create(DeliveryItem deliveryItem)
        => context.Add(deliveryItem);

    public void Delete(Guid itemId, Guid deliveryId)
    {
        var entity = dbSet.Find(itemId, deliveryId);

        if (entity is not null)
            dbSet.Remove(entity);
    }
}