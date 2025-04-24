using MediatR;

namespace Almox.Application.Features.Users.Find;

public sealed record FindUserRequest(
    string Id
) : IRequest<FindUserResponse>;