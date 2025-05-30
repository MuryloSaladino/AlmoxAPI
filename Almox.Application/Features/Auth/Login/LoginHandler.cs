using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.Users;
using Almox.Application.Contracts;
using Almox.Domain.Common.Exceptions;
using Almox.Application.Repository;
using AutoMapper;

namespace Almox.Application.Features.Auth.Login;

public sealed class LoginHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IAuthenticator authenticator,
    IUnitOfWork unitOfWork,
    IMapper mapper
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

        var accessToken = authenticator.GenerateToken(user);
        var refreshToken = Guid.NewGuid().ToString();

        user.RefreshToken = refreshToken; 
        userRepository.Update(user);
        await unitOfWork.Save(cancellationToken);

        var userPresenter = mapper.Map<LoginUserPresenter>(user);

        return new LoginResponse(accessToken, refreshToken, userPresenter);
    }
}