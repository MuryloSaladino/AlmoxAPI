using Almox.Domain.Entities;

namespace Almox.Domain.Repository.UsersRepository;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken);
    Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
    Task<User?> GetWithAlmox(Guid id, CancellationToken cancellationToken);
    Task<List<User>> GetAllWithAlmox(CancellationToken cancellationToken);
    Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken);
}