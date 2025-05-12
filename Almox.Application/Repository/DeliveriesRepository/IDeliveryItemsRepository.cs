using Almox.Domain.Entities;

namespace Almox.Application.Repository.DeliveriesRepository;

public interface IDeliveryItemsRepository 
{
    void Create(DeliveryItem deliveryItem);
    void Delete(Guid itemId, Guid deliveryId);
}