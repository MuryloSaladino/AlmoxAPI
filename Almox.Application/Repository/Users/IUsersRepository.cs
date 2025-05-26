using Almox.Domain.Entities;

namespace Almox.Application.Repository.Users;

public record UserFilters : PaginatedFilter
{
    public string? Username { get; init; }
    public string? Email { get; init; }
}

public interface IUsersRepository
    : IBaseRepository<User, UserFilters>
{
    Task<User?> GetByUsernameOrEmail(string search, CancellationToken cancellationToken);
}