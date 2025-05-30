using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.GetAll;

public class GetAllUsersHandler(
    IUsersRepository usersRepository,
    IMapper mapper
) : IRequestHandler<GetAllUsersRequest, PaginatedResult<GetAllUsersResponse>>
{
    public async Task<PaginatedResult<GetAllUsersResponse>> Handle(
        GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await usersRepository.GetAll(request, cancellationToken);

        return mapper.Map<PaginatedResult<GetAllUsersResponse>>(users);
    }
}