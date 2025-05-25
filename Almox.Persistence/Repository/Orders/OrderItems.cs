using Almox.Application.Repository.Orders;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Orders;

public class OrderItemsRepository(
    AlmoxContext context
) : IOrderItemsRepository
{
    public void Create(OrderItem requestItem)
        => context.Add(requestItem);

    public void Delete(Guid itemId, Guid requestId)
    {
        var entity = context.Set<OrderItem>().Find(itemId, requestId);

        if (entity is not null)
            context.Set<OrderItem>().Remove(entity);
    }

    public Task<OrderItem?> Get(Guid itemId, Guid orderId, CancellationToken cancellationToken)
        => context.Set<OrderItem>()
            .Where(oi => oi.OrderId == orderId)
            .Where(oi => oi.ItemId == itemId)
            .FirstOrDefaultAsync(cancellationToken);
}