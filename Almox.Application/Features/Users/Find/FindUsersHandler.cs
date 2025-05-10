using Almox.Application.Repository.UsersRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.Find;

public class FindUsersHandler(
    IUsersRepository usersRepository,
    IMapper mapper
) : IRequestHandler<FindUsersRequest, List<FindUsersResponse>>
{
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly IMapper mapper = mapper;
    
    public async Task<List<FindUsersResponse>> Handle(FindUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await usersRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindUsersResponse>>(users);
    }
}