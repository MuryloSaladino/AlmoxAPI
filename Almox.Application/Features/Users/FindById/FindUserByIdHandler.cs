using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.UsersRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.FindById;

public sealed class FindUserByIdHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUserByIdRequest, FindUserByIdResponse>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;

    public async Task<FindUserByIdResponse> Handle(FindUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.User);
    
        return mapper.Map<FindUserByIdResponse>(user);
    }
}