using AutoMapper;
using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Contracts;
using Almox.Domain.Entities;
using Almox.Application.Repository;
using Almox.Application.Repository.UsersRepository;

namespace Almox.Application.Features.Users.Register;

public sealed class RegisterUserHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IPasswordEncrypter encrypter = encrypter;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;


    public async Task<RegisterUserResponse> Handle(
        RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        bool exists = await userRepository.ExistsByUsername(request.Username, cancellationToken);
        if(exists) throw new AppException("Username already taken", AppExceptionCode.BadRequest);

        var user = mapper.Map<User>(request);
        user.Password = encrypter.Hash(user);
        userRepository.Create(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<RegisterUserResponse>(user);
    }
}