using AutoMapper;
using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.UsersRepository;
using Almox.Application.Repository;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Features.Users.Promote;

public sealed class PromoteUserHandler(
    IUsersRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<PromoteUserRequest, PromoteUserResponse>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<PromoteUserResponse> Handle(
        PromoteUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.User);

        user.IsAdmin = true;
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<PromoteUserResponse>(user);
    }
}