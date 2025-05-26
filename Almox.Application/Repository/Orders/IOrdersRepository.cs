using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;

namespace Almox.Application.Repository.Orders;

public record OrderFilters : PaginatedFilter
{
    public OrderStatus? Status { get; init; }
}

public interface IOrdersRepository
    : IBaseRepository<Order, OrderFilters>
{
    Task<Order?> GetUserCartOrder(Guid userId, CancellationToken cancellationToken);
    Task<PaginatedResult<Order>> GetAllByUser(
        Guid userId, OrderFilters filters, CancellationToken cancellationToken);
}