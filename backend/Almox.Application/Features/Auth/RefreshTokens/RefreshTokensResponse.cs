namespace Almox.Application.Features.Auth.RefreshTokens;

public sealed record RefreshTokensResponse(
    string AccessToken,
    string RefreshToken
);