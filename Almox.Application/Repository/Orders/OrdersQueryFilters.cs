using Almox.Domain.Common.Enums;

namespace Almox.Application.Repository.Orders;

public record OrdersQueryFilters(
    Guid? UserId,
    OrderStatus? Status
);