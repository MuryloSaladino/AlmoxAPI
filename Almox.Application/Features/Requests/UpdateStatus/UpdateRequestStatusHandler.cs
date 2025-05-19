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
    IRequestHistoryRepository historyRepository,
    IRequestsRepository requestsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateRequestStatusRequest, UpdateRequestStatusResponse>
{
    private readonly IRequestHistoryRepository historyRepository = historyRepository;
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateRequestStatusResponse> Handle(
        UpdateRequestStatusRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var almoxRequest = await requestsRepository.GetWithItems(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Request);

        ValidateOrThrow(request.Status, almoxRequest, session);
        ApplyChanges(almoxRequest, request.Status);
        SaveHistory(session.UserId, request.Id, request.Status);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateRequestStatusResponse>(almoxRequest);
    }

    private static void ValidateOrThrow(RequestStatus status, Request request, SessionData session)
    {
        switch (status)
        {
            case RequestStatus.Draft:
                throw new ConflictException(ExceptionMessages.Conflict.ResourceState);

            case RequestStatus.Requested:
                if (request.UserId != session.UserId)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.NotOwnUser);
                break;

            case RequestStatus.Accepted:
            case RequestStatus.Ready:
            case RequestStatus.Completed:
                if (!session.IsAdmin)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);
                break;

            case RequestStatus.Canceled:
                if (!session.IsAdmin && request.UserId != session.UserId)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);
                break;
        }
    }

    private static void ApplyChanges(Request request, RequestStatus status)
    {
        switch (status)
        {
            case RequestStatus.Completed:
                foreach (var requestItem in request.RequestItems)
                    requestItem.Item.Quantity -= requestItem.FulfilledQuantity;
                break;
            default:
                break;
        }
        request.Status = status;
    }

    private void SaveHistory(Guid userId, Guid requestId, RequestStatus status)
    {
        var history = new RequestHistory()
        {
            RequestId = requestId,
            Request = null!,
            UpdatedById = userId,
            UpdatedBy = null!,
            Status = status,
        };
        historyRepository.Create(history);
    }
}