using Almox.Application.Repository.Users;
using MediatR;

namespace Almox.Application.Features.Users.GetAll;

public sealed record GetAllUsersRequest
    : UserFilters, IRequest<List<GetAllUsersResponse>>;
