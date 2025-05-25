using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.Users;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.FindById;

public sealed class FindUserByIdHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindUserByIdRequest, FindUserByIdResponse>
{
    public async Task<FindUserByIdResponse> Handle(
        FindUserByIdRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var user = await usersRepository.Get(request.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);
    
        return mapper.Map<FindUserByIdResponse>(user);
    }
}