using AutoMapper;
using MediatR;
using Almox.Domain.Entities;
using Almox.Application.Repository;
using Almox.Application.Repository.UsersRepository;
using Almox.Application.Contracts;

namespace Almox.Application.Features.Users.Register;

public sealed class RegisterUserHandler(
    IUsersRepository usersRepository,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly IPasswordEncrypter encrypter = encrypter;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);

        user.Password = encrypter.Hash(user);

        usersRepository.Create(user);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}