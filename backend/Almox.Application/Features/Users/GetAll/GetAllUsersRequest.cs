using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using MediatR;

namespace Almox.Application.Features.Users.GetAll;

public sealed record GetAllUsersRequest
    : UserFilters, IRequest<PaginatedResult<GetAllUsersResponse>>;
