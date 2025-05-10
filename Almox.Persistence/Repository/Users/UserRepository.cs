using Microsoft.EntityFrameworkCore;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Almox.Application.Repository.UsersRepository;

namespace Almox.Persistence.Repository.Users;

public class UserRepository(
    AlmoxContext almoxContext
) : BaseRepository<User>(almoxContext), 
    IUsersRepository
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