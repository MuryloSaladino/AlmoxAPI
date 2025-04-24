using Almox.Domain.Common;

namespace Almox.Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required bool IsAdmin { get; set; }
    public List<Skill> Skills { get; set; } = [];
}
