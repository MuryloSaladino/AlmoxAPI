using Almox.Application.Repository.UsersRepository;
using MediatR;

namespace Almox.Application.Features.Users.Find;

public sealed record FindUsersRequest(
    UsersQueryFilters Filters
) : IRequest<List<FindUsersResponse>>;
