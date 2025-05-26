using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Users.Register;

public sealed record RegisterUserRequest(
    Guid DepartmentId,
    string Username,
    string Email,
    UserRole Role
) : IRequest<RegisterUserResponse>;
