using Almox.Application.Repository.Orders;
using MediatR;

namespace Almox.Application.Features.Orders.GetAll;

public sealed record GetAllOrdersRequest(
    OrderFilters Filters
) : IRequest<List<GetAllOrdersResponse>>;