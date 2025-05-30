using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Auth.Login;

public sealed record LoginResponse(
    string AccessToken,
    string RefreshToken,
    LoginUserPresenter User
);

public sealed record LoginUserPresenter(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    UserRole Role,
    string DepartmentName,
    Guid DepartmentId
);
