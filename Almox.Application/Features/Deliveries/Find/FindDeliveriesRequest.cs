using Almox.Application.Repository.DeliveriesRepository;
using MediatR;

namespace Almox.Application.Features.Deliveries.Find;

public sealed record FindDeliveriesRequest(
    DeliveriesQueryFilters Filters
) : IRequest<FindDeliveriesResponse>;