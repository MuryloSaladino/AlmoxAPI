using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.GetAll;

public class GetAllUsersHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllUsersRequest, PaginatedResult<GetAllUsersResponse>>
{
    public async Task<PaginatedResult<GetAllUsersResponse>> Handle(
        GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var users = await usersRepository.GetAll(request, cancellationToken);

        return mapper.Map<PaginatedResult<GetAllUsersResponse>>(users);
    }
}