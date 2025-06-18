using Almox.Domain.Entities;

namespace Almox.Application.Repository.Deliveries;

public interface IDeliveryStatusUpdatesRepository
{
    void Create(DeliveryStatusUpdate statusUpdate);
}