using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.RequestsRepository;
using Almox.Application.Repository.UsersRepository;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.Create;

public class CreateRequestHandler(
    IRequestsRepository requestsRepository,
    IUsersRepository usersRepository,
    IUserSession userSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateRequestRequest, CreateRequestResponse>
{
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateRequestResponse> Handle(CreateRequestRequest request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.Get(userSession.GetSession().UserId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.User);

        Request requestCreation = new()
        {
            User = user,
            UserId = user.Id
        };
        requestsRepository.Create(requestCreation);

        await unitOfWork.Save(cancellationToken);   

        return mapper.Map<CreateRequestResponse>(requestCreation);
    }
}