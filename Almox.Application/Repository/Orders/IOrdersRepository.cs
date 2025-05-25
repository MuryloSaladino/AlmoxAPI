using Almox.Domain.Entities;

namespace Almox.Application.Repository.Orders;

public interface IOrdersRepository : IBaseRepository<Order>
{
    Task<List<Order>> GetWithFilters(OrdersQueryFilters filters, CancellationToken cancellationToken);
    Task<Order?> GetWithItems(Guid id, CancellationToken cancellationToken);
    Task<Order?> GetUserCartOrder(Guid userId, CancellationToken cancellationToken);
}