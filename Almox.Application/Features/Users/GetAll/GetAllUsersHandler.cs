using Almox.Application.Common.Session;
using Almox.Application.Repository.Users;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.GetAll;

public class GetAllUsersHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllUsersRequest, List<GetAllUsersResponse>>
{
    public async Task<List<GetAllUsersResponse>> Handle(
        GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetStaffSessionOrThrow();

        var users = await usersRepository.GetAll(request.Filters, cancellationToken);

        return mapper.Map<List<GetAllUsersResponse>>(users);
    }
}