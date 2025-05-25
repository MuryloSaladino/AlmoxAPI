using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.Users;
using Almox.Application.Contracts;
using Almox.Domain.Common.Exceptions;

namespace Almox.Application.Features.Auth.Login;

public sealed class LoginHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IAuthenticator authenticator
) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameOrEmail(
            request.UserIdentifier, cancellationToken)
                ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);
        
        if(!encrypter.Matches(user, request.Password)) 
            throw AppException.Unauthorized(ExceptionMessages.Unauthorized.Credentials);
        
        var token = authenticator.GenerateUserToken(user);

        return new LoginResponse(token);
    }
}