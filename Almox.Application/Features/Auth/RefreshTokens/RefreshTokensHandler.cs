using Almox.Application.Common.Exceptions;
using Almox.Application.Contracts;
using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using Almox.Domain.Common.Exceptions;
using MediatR;

namespace Almox.Application.Features.Auth.RefreshTokens;

public class RefreshTokensHandler(
    IUsersRepository usersRepository,
    IAuthenticator authenticator,
    IUnitOfWork unitOfWork
) : IRequestHandler<RefreshTokensRequest, RefreshTokensResponse>
{
    public async Task<RefreshTokensResponse> Handle(
        RefreshTokensRequest request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.Get(request.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);

        if (user.RefreshToken != request.RefreshToken)
            throw AppException.Unauthorized(ExceptionMessages.Unauthorized.RefreshToken);

        var accessToken = authenticator.GenerateToken(user);
        var refreshToken = Guid.NewGuid().ToString();

        user.RefreshToken = refreshToken;
        usersRepository.Update(user);
        await unitOfWork.Save(cancellationToken);

        return new RefreshTokensResponse(accessToken, refreshToken);
    }
}
