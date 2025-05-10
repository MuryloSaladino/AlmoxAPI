using Almox.Application.Repository.DeliveriesRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Deliveries;

public class DeliveriesRepository(
    AlmoxContext almoxContext
) : BaseRepository<Delivery>(almoxContext), IDeliveriesRepository {}
