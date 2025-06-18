using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.Users;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Auth.GetLoggedUser;

public sealed class GetLoggedUserHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetLoggedUserRequest, GetLoggedUserResponse>
{
    public async Task<GetLoggedUserResponse> Handle(
        GetLoggedUserRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var user = await usersRepository.Get(session.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);
    
        return mapper.Map<GetLoggedUserResponse>(user);
    }
}