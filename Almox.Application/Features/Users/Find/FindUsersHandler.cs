using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.Users;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Users.Find;

public class FindUsersHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindUsersRequest, List<FindUsersResponse>>
{
    public async Task<List<FindUsersResponse>> Handle(
        FindUsersRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var users = await usersRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindUsersResponse>>(users);
    }
}