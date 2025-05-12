using Almox.Application.Repository.RequestsRepository;
using MediatR;

namespace Almox.Application.Features.Requests.Find;

public sealed record FindRequestsRequest(
    RequestsQueryFilters Filters 
) : IRequest<List<FindRequestsResponse>>;