using Almox.Domain.Entities;

namespace Almox.Application.Repository.Deliveries;

public interface IDeliveryItemsRepository 
{
    void Create(DeliveryItem deliveryItem);
    void Delete(Guid itemId, Guid deliveryId);
}