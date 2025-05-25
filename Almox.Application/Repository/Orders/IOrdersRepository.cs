using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Repository.Orders;

public record OrderFilters(
    Guid? UserId,
    OrderStatus? Status
);

public interface IOrdersRepository
    : IBaseRepository<Order, OrderFilters>
{
    Task<Order?> GetUserCartOrder(Guid userId, CancellationToken cancellationToken);
}