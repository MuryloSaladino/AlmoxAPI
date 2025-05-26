using AutoMapper;
using MediatR;
using Almox.Domain.Entities;
using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using Almox.Application.Contracts;
using Almox.Application.Common.Generators;
using Almox.Application.Common.Session;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Users.Register;

public sealed class RegisterUserHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        if (request.Role.Equals(UserRole.Admin))
            requestSession.GetAdminSessionOrThrow();
        else
            requestSession.GetStaffSessionOrThrow();

        var user = mapper.Map<User>(request);
        user.Password = PasswordGenerator.GenerateStrongPassword();
        user.Password = encrypter.Hash(user);

        usersRepository.Create(user);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}