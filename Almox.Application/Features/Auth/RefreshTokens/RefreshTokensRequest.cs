using MediatR;

namespace Almox.Application.Features.Auth.RefreshTokens;

public sealed record RefreshTokensRequest(
    Guid UserId,
    string RefreshToken
) : IRequest<RefreshTokensResponse>;