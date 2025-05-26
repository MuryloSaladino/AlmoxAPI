using MediatR;

namespace Almox.Application.Features.Users.Get;

public sealed record GetUserRequest(
    Guid UserId
) : IRequest<GetUserResponse>;