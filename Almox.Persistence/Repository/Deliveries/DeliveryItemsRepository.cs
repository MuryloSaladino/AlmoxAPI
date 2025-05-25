using Almox.Application.Repository.Deliveries;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Deliveries;

public class DeliveryItemsRepository(
    AlmoxContext context
) : IDeliveryItemsRepository
{
    public void Create(DeliveryItem deliveryItem)
        => context.Add(deliveryItem);

    public void Delete(Guid itemId, Guid deliveryId)
    {
        var entity = context.Set<DeliveryItem>().Find(itemId, deliveryId);

        if (entity is not null)
            context.Set<DeliveryItem>().Remove(entity);
    }
}