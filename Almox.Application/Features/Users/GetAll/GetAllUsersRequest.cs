using Almox.Application.Repository.Users;
using MediatR;

namespace Almox.Application.Features.Users.GetAll;

public sealed record GetAllUsersRequest(
    UserFilters Filters
) : IRequest<List<GetAllUsersResponse>>;
