using Almox.Application.Repository;
using Almox.Application.Repository.Orders;
using MediatR;

namespace Almox.Application.Features.Orders.GetAll;

public sealed record GetAllOrdersRequest
    : OrderFilters, IRequest<PaginatedResult<GetAllOrdersResponse>>;