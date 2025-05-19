using Almox.Domain.Common.Enums;

namespace Almox.Application.Repository.OrdersRepository;

public record OrdersQueryFilters(
    Guid? UserId,
    OrderStatus? Status
);