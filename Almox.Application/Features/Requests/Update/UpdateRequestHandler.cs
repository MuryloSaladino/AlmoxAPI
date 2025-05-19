using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.Update;

public class UpdateRequestHandler(
    IRequestsRepository requestsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateRequestRequest, UpdateRequestResponse>
{
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateRequestResponse> Handle(
        UpdateRequestRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var almoxRequest = await requestsRepository.GetWithItems(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Request);

        if(session.UserId != almoxRequest.UserId)
            throw new ForbiddenException(ExceptionMessages.Forbidden.NotOwnUser);

        almoxRequest.Priority = request.Body.Priority;
        almoxRequest.Observations = request.Body.Observations;

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateRequestResponse>(almoxRequest);
    }
}