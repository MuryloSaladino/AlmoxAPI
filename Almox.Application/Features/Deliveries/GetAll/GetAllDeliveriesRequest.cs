using Almox.Application.Repository.Deliveries;
using MediatR;

namespace Almox.Application.Features.Deliveries.GetAll;

public sealed record GetAllDeliveriesRequest(
    DeliveryFilters Filters
) : IRequest<List<GetAllDeliveriesResponse>>;