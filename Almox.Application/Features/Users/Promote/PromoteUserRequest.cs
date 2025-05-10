using MediatR;

namespace Almox.Application.Features.Users.Promote;

public sealed record PromoteUserRequest(
    Guid Id
) : IRequest<PromoteUserResponse>;
