using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class User : BaseEntity
{
    public required Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsAdmin { get; set; } = false;
}
