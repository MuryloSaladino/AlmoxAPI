using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.FindById;

public class FindRequestByIdHandler(
    IRequestsRepository requestsRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindRequestByIdRequest, FindRequestByIdResponse>
{   
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<FindRequestByIdResponse> Handle(FindRequestByIdRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var almoxRequest = await requestsRepository.GetWithItems(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Request);

        if(!session.IsAdmin && almoxRequest.UserId != session.UserId)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        return mapper.Map<FindRequestByIdResponse>(almoxRequest);
    }
}