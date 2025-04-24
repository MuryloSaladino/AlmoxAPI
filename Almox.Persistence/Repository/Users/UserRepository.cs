using Microsoft.EntityFrameworkCore;
using Almox.Domain.Entities;
using Almox.Domain.Repository.UsersRepository;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Users;

public class UserRepository(AlmoxContext AlmoxContext) : BaseRepository<User>(AlmoxContext), IUsersRepository
{
    public Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .AnyAsync(user => user.Username == username, cancellationToken);

    public Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Username == username, cancellationToken);

}