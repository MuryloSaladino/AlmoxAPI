using Almox.Application.Repository.Users;
using MediatR;

namespace Almox.Application.Features.Users.Find;

public sealed record FindUsersRequest(
    UsersQueryFilters Filters
) : IRequest<List<FindUsersResponse>>;
