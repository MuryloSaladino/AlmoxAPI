using MediatR;

namespace Almox.Application.Features.Users.Promote;

public sealed record PromoteUserRequest(
    string Id
) : IRequest<PromoteUserResponse>;
