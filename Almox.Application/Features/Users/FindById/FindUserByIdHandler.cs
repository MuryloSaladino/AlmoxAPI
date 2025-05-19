using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.UsersRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.FindById;

public sealed class FindUserByIdHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindUserByIdRequest, FindUserByIdResponse>
{
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<FindUserByIdResponse> Handle(
        FindUserByIdRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin && request.UserId != session.UserId)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUserNorAdmin);

        var user = await usersRepository.Get(request.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);
    
        return mapper.Map<FindUserByIdResponse>(user);
    }
}