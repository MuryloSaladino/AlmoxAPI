using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using Almox.Domain.Common.Exceptions;
using MediatR;

namespace Almox.Application.Features.Auth.Logout;

public class LogoutHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<LogoutRequest, LogoutResponse>
{
    public async Task<LogoutResponse> Handle(
        LogoutRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var user = await usersRepository.Get(session.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);

        user.RefreshToken = null;
        usersRepository.Update(user);
        await unitOfWork.Save(cancellationToken);

        return new LogoutResponse();
    }
}
