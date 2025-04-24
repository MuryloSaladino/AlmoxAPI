using Almox.Domain.Repository.UsersRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.Find;

public sealed class FindUserHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUserRequest, FindUserResponse>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;

    public async Task<FindUserResponse> Handle(FindUserRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("not implemented");
    }
}