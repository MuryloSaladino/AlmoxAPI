using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.UsersRepository;
using Almox.Application.Contracts;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Features.Auth.Login;

public sealed class LoginHandler(
    IPasswordEncrypter encrypter,
    IUsersRepository userRepository,
    IAuthenticator authentication
) : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IPasswordEncrypter encrypter = encrypter;
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IAuthenticator authentication = authentication;

    public async Task<LoginResponse> Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsername(request.Username, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);
        
        if(!encrypter.Matches(user, request.Password)) 
            throw AppException.Unauthorized(ExceptionMessages.Unauthorized.Credentials);
        
        var token = authentication.GenerateUserToken(user);

        return new LoginResponse(token);
    }
}