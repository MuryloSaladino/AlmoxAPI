using Almox.Application.Common.Exceptions;
using Almox.Application.Repository;
using Almox.Application.Repository.RequestsRepository;
using Almox.Application.Repository.UsersRepository;
using Almox.Domain.Common;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.Create;

public class CreateRequestHandler(
    IRequestsRepository requestsRepository,
    IUsersRepository usersRepository,
    UserSession userSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateRequestRequest, CreateRequestResponse>
{
    private readonly IRequestsRepository requestsRepository = requestsRepository;
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly UserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateRequestResponse> Handle(CreateRequestRequest request, CancellationToken cancellationToken)
    {
        if(userSession.Id is Guid userId)
        {
            var user = await usersRepository.Get(userId, cancellationToken)
                ?? throw new AppException("User does not exist in database anymore", AppExceptionCode.Unauthorized);

            Request requestCreation = new()
            {
                User = user,
                UserId = user.Id
            };
            requestsRepository.Create(requestCreation);

            await unitOfWork.Save(cancellationToken);   

            return mapper.Map<CreateRequestResponse>(requestCreation);
        }
        throw new AppException("Unauthorized", AppExceptionCode.Unauthorized);
    }
}