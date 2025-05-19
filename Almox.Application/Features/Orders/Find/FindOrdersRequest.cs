using Almox.Application.Repository.OrdersRepository;
using MediatR;

namespace Almox.Application.Features.Orders.Find;

public sealed record FindOrdersRequest(
    OrdersQueryFilters Filters 
) : IRequest<List<FindOrdersResponse>>;