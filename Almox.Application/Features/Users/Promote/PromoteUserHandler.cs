using AutoMapper;
using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.UsersRepository;
using Almox.Application.Repository;
using Almox.Domain.Common.Messages;
using Almox.Application.Common.Session;

namespace Almox.Application.Features.Users.Promote;

public sealed class PromoteUserHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<PromoteUserRequest, PromoteUserResponse>
{
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<PromoteUserResponse> Handle(
        PromoteUserRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var user = await usersRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.User);

        user.IsAdmin = true;

        usersRepository.Update(user);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<PromoteUserResponse>(user);
    }
}