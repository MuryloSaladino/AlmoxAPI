using Almox.Application.Repository.Deliveries;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Deliveries;

public class DeliveryHistoryRepository(
    AlmoxContext almoxContext
) : BaseRepository<DeliveryHistory>(almoxContext), IDeliveryHistoryRepository {}
