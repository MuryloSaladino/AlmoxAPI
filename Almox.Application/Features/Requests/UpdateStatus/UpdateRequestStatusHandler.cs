using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using Almox.Domain.Objects;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.UpdateStatus;

public class UpdateRequestStatusHandler(
    IRequestsRepository requestsRepository,
    IUserSession userSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateRequestStatusRequest, UpdateRequestStatusResponse>
{
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateRequestStatusResponse> Handle(
        UpdateRequestStatusRequest request, CancellationToken cancellationToken)
    {
        var session = userSession.GetSession();
        var almoxRequest = await requestsRepository.GetWithItems(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Request);

        ValidateOrThrow(request.Status, almoxRequest, session);

        almoxRequest.Status = request.Status;
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateRequestStatusResponse>(almoxRequest);
    }

    private static void ValidateOrThrow(RequestStatus status, Request request, AuthPayload session)
    {
        switch(status)
        {
            case RequestStatus.Draft:
                throw new ConflictException(ExceptionMessages.Conflict.ResourceState);

            case RequestStatus.Requested:
                if(request.UserId != session.UserId)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.NotOwnUser);
                break;

            case RequestStatus.Accepted:
            case RequestStatus.Ready:
            case RequestStatus.Completed:
                if(!session.IsAdmin)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);
                break;

            case RequestStatus.Canceled:
                if(!session.IsAdmin && request.UserId != session.UserId)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);
                break;
        }
    }
}