using Almox.Application.Repository.DepartmentsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Departments;

public class DepartmentsRepository(
    AlmoxContext almoxContext
) : BaseRepository<Department>(almoxContext), IDepartmentRepository
{
    public async Task<List<Department>> GetByName(string? name, CancellationToken cancellationToken)
        => await dbSet
            .Where(d => name == null || EF.Functions.ILike(d.Name, $"%{name}%"))
            .ToListAsync(cancellationToken);

    public async Task<Department?> GetWithUsers(Guid id, CancellationToken cancellationToken)
        => await dbSet
            .Include(d => d.Users)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
}