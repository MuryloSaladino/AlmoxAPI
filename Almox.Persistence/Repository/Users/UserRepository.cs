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

    public Task<User?> GetWithAlmox(Guid id, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .Include(user => user.Almox.Where(skill => skill.DeletedAt == null))
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

    public Task<List<User>> GetAllWithAlmox(CancellationToken cancellationToken)
        => context
            .Set<User>()
            .Include(user => user.Almox.Where(skill => skill.DeletedAt == null))
            .ToListAsync(cancellationToken);

    public Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .Where(user => user.Almox.Any(skill => 
                skill.Name.ToLower().Contains(skillName.ToLower()) && 
                skill.DeletedAt == null))
            .Include(user => user.Almox)
            .ToListAsync(cancellationToken);
}