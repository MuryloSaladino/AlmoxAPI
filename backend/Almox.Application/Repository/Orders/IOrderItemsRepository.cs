using Almox.Domain.Entities;

namespace Almox.Application.Repository.Orders;

public interface IOrderItemsRepository
{
    void Create(OrderItem orderItem);
    void Delete(Guid itemId, Guid orderId);
    Task<OrderItem?> Get(Guid itemId, Guid orderId, CancellationToken cancellationToken);
}