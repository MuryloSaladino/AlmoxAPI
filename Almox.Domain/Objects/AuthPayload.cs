namespace Almox.Domain.Objects;

public class SessionData
{
    public required Guid UserId { get; set; }
    public bool IsAdmin { get; set; } = false;
}