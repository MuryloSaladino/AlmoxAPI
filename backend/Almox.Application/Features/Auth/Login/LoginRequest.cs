using MediatR;

namespace Almox.Application.Features.Auth.Login;

public sealed record LoginRequest(
    string UserIdentifier,
    string Password
) : IRequest<LoginResponse>;
