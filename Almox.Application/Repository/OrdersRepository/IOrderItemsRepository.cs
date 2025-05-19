using Almox.Domain.Entities;

namespace Almox.Application.Repository.OrdersRepository;

public interface IOrderItemsRepository
{
    void Create(OrderItem orderItem);
    void Delete(Guid itemId, Guid deliveryId);
}