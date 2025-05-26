using Microsoft.EntityFrameworkCore;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Almox.Application.Repository.Users;

namespace Almox.Persistence.Repository.Users;

public class UserRepository(
    AlmoxContext context
) : BaseRepository<User>(context), IUsersRepository
{
    public Task<User?> GetByUsernameOrEmail(string search, CancellationToken cancellationToken)
        => context.Set<User>()
            .Where(u => u.DeletedAt == null)
            .Where(u => u.Username == search || u.Email == search)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<List<User>> GetAll(UserFilters filters, CancellationToken cancellationToken)
        => context.Set<User>()
            .Where(u => u.DeletedAt == null)
            .Where(u => filters.Username == null || EF.Functions.ILike(u.Username, $"%{filters.Username}%"))
            .Where(u => filters.Email == null || EF.Functions.ILike(u.Email, $"%{filters.Email}%"))
            .ToListAsync(cancellationToken);
}