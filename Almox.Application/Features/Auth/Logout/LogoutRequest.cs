using MediatR;

namespace Almox.Application.Features.Auth.Logout;

public sealed record LogoutRequest : IRequest<LogoutResponse>;