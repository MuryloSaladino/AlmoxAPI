using Almox.Domain.Common.Enums;

namespace Almox.Domain.Entities;

public class User : BaseEntity
{
    public required Guid DepartmentId { get; set; }
    public required Department Department { get; set; }

    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required UserRole Role { get; set; }
    public string? RefreshToken { get; set; } = null;
}
