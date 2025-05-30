namespace Almox.Application.Features.Auth.Login;

public sealed record LoginResponse(
    DateTime ExpiresAt,
    string AccessToken,
    string RefreshToken
);
