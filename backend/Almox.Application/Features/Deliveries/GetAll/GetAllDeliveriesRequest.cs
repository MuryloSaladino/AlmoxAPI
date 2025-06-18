using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using MediatR;

namespace Almox.Application.Features.Deliveries.GetAll;

public sealed record GetAllDeliveriesRequest
    : DeliveryFilters, IRequest<PaginatedResult<GetAllDeliveriesResponse>>;