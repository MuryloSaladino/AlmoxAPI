using Almox.Application.Repository.Users;
using MediatR;

namespace Almox.Application.Features.Users.Count;

public class CountUsersHandler(
    IUsersRepository departmentRepository
) : IRequestHandler<CountUsersRequest, CountUsersResponse>
{
    public async Task<CountUsersResponse> Handle(
        CountUsersRequest request, CancellationToken cancellationToken)
    {
        var count = await departmentRepository.Count(cancellationToken);
        
        return new CountUsersResponse(count);
    }
}