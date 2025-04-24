using Microsoft.EntityFrameworkCore;
using Almox.Domain.Entities;
using Almox.Domain.Repository.AlmoxRepository;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Almox;

public class SkillRepository(AlmoxContext AlmoxContext) : BaseRepository<Skill>(AlmoxContext), IAlmoxRepository
{
    public Task<List<Skill>> GetByMinLevel(int level, CancellationToken cancellationToken)
        => context
            .Set<Skill>()
            .Where(skill => skill.Level >= level)
            .ToListAsync(cancellationToken);

    public Task<bool> ExistsForUser(Guid id, Guid userId, CancellationToken cancellationToken)
        => dbSet.AnyAsync(skill => 
            skill.Id == id && 
            skill.UserId == userId &&
            skill.DeletedAt == null, 
        cancellationToken);
}