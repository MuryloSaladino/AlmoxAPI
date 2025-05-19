using Almox.Application.Repository.OrdersRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Orders;

public class OrderItemsRepository(
    AlmoxContext almoxContext
) : IOrderItemsRepository
{
    private readonly AlmoxContext context = almoxContext;
    private readonly DbSet<OrderItem> dbSet = almoxContext.Set<OrderItem>();

    public void Create(OrderItem requestItem)
        => context.Add(requestItem);

    public void Delete(Guid itemId, Guid requestId)
    {
        var entity = dbSet.Find(itemId, requestId);

        if (entity is not null)
            dbSet.Remove(entity);
    }
}