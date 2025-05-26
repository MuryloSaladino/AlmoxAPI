using Almox.Application.Repository.Orders;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Orders;

public class OrderStatusUpdateRepository(
    AlmoxContext context
) : IOrderStatusUpdatesRepository
{
    public void Create(OrderStatusUpdate statusUpdate)
        => context.Add(statusUpdate);
}
