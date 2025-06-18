using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.Users;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.Get;

public sealed class GetUserHandler(
    IUsersRepository usersRepository,
    IMapper mapper
) : IRequestHandler<GetUserRequest, GetUserResponse>
{
    public async Task<GetUserResponse> Handle(
        GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.Get(request.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);
    
        return mapper.Map<GetUserResponse>(user);
    }
}