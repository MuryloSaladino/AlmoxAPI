using Almox.Domain.Entities;

namespace Almox.Application.Repository.Orders;

public interface IOrderStatusUpdatesRepository
{
    void Create(OrderStatusUpdate statusUpdate);
}