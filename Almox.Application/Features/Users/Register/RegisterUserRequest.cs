using MediatR;

namespace Almox.Application.Features.Users.Register;

public sealed record RegisterUserRequest(
    Guid DepartmentId,
    string Username,
    string Email,
    string Password
) : IRequest<RegisterUserResponse>;
