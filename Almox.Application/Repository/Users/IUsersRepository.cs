using Almox.Domain.Entities;

namespace Almox.Application.Repository.Users;

public record UserFilters(
    string? Username,
    string? Email
);

public interface IUsersRepository : IBaseRepository<User, UserFilters>
{
    Task<User?> GetByUsernameOrEmail(string search, CancellationToken cancellationToken);
}