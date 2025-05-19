using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.Find;

public class FindRequestsHandler(
    IRequestsRepository requestsRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindRequestsRequest, List<FindRequestsResponse>>
{
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindRequestsResponse>> Handle(FindRequestsRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if(!session.IsAdmin && request.Filters.UserId != session.UserId)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var requests = await requestsRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindRequestsResponse>>(requests);
    }
}