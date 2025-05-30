using AutoMapper;
using MediatR;
using Almox.Domain.Entities;
using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using Almox.Application.Contracts;
using Almox.Application.Common.Generators;
using Almox.Application.Repository.Departments;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Common.Exceptions;

namespace Almox.Application.Features.Users.Register;

public sealed class RegisterUserHandler(
    IDepartmentRepository departmentRepository,
    IUsersRepository usersRepository,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.Get(request.DepartmentId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Department);

        var user = mapper.Map<User>(request);
        user.Department = department;
        user.Password = PasswordGenerator.GenerateStrongPassword();
        user.Password = encrypter.Hash(user);

        usersRepository.Create(user);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}