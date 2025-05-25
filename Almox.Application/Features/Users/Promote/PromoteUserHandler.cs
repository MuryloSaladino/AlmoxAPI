using AutoMapper;
using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.Users;
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
    public async Task<PromoteUserResponse> Handle(
        PromoteUserRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var user = await usersRepository.Get(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);

        user.IsAdmin = true;

        usersRepository.Update(user);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<PromoteUserResponse>(user);
    }
}