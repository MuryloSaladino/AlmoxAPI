using Almox.Application.Repository.Orders;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Orders;

public class OrderHistoryRepository(
    AlmoxContext almoxContext
) : BaseRepository<OrderHistory>(almoxContext), IOrderHistoryRepository;
