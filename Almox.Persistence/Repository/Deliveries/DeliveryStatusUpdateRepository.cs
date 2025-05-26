using Almox.Application.Repository.Deliveries;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Deliveries;

public class DeliveryStatusUpdateRepository(
    AlmoxContext context
) : IDeliveryStatusUpdatesRepository
{
    public void Create(DeliveryStatusUpdate statusUpdate)
        => context.Add(statusUpdate);
}
