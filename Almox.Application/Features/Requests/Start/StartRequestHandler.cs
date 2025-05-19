using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.RequestsRepository;
using Almox.Application.Repository.UsersRepository;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.Start;

public class StartRequestHandler(
    IRequestsRepository requestsRepository,
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<StartRequestRequest, StartRequestResponse>
{
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<StartRequestResponse> Handle(StartRequestRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var user = await usersRepository.Get(session.UserId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.User);

        var draftFilter = new RequestsQueryFilters(user.Id, RequestStatus.Draft);

        var almoxRequest = (await requestsRepository.GetWithFilters(
            draftFilter, cancellationToken)).First();

        if(almoxRequest is null)
        {
            almoxRequest = new()
            {
                User = user,
                UserId = user.Id
            };
            requestsRepository.Create(almoxRequest);
            await unitOfWork.Save(cancellationToken);
        }

        return mapper.Map<StartRequestResponse>(almoxRequest);
    }
}