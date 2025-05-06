using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Contracts;
using Almox.Domain.Repository.UsersRepository;

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
            ?? throw new AppException("User not found", AppExceptionCode.NotFound);
        
        if(!encrypter.Matches(user, request.Password)) 
            throw new AppException("Credentials do not match", AppExceptionCode.Forbidden);
        
        var token = authentication.GenerateUserToken(user);

        return new LoginResponse(token);
    }
}