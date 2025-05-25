using Almox.Domain.Common.Enums;

namespace Almox.Domain.Objects;

public class SessionData
{
    public required Guid UserId { get; init; }
    public required Guid DepartmentId { get; init; }
    public required UserRole Role { get; init; }
}