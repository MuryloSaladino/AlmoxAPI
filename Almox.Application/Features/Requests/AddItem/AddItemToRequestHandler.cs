using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.AddItem;

public class AddItemToRequestHandler(
    IRequestItemsRepository requestItemsRepository,
    IRequestsRepository requestsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<AddItemToRequestRequest, AddItemToRequestResponse>
{
    private readonly IRequestItemsRepository requestItemsRepository = requestItemsRepository;
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<AddItemToRequestResponse> Handle(AddItemToRequestRequest request, CancellationToken cancellationToken)
    {
        var referencedRequest = await requestsRepository.Get(request.RequestId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Request);

        var session = requestSession.GetSessionOrThrow();

        if(session.UserId != referencedRequest.UserId && !session.IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.NotOwnUserNorAdmin);

        var itemAddition = mapper.Map<RequestItem>(request);
        requestItemsRepository.Create(itemAddition);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AddItemToRequestResponse>(itemAddition);
    }
}