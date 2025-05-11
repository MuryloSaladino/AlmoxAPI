namespace Almox.Domain.Objects;

public class AuthPayload
{
    public required Guid UserId { get; set; }
    public required string Username { get; set; }
    public bool IsAdmin { get; set; } = false;
}