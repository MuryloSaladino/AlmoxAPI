using Almox.Application.Repository.DepartmentsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Departments;

public class DepartmentsRepository(
    AlmoxContext almoxContext
) : BaseRepository<Department>(almoxContext), IDepartmentRepository
{
    public async Task<List<Department>> GetWithFilters(
        DepartmentsQueryFilters filters, 
        CancellationToken cancellationToken
    ) => await dbSet
            .Where(d => d.DeletedAt == null)
            .Where(d => filters.Name == null || EF.Functions.ILike(d.Name, $"%{filters.Name}%"))
            .ToListAsync(cancellationToken);

    public async Task<Department?> GetWithUsers(Guid id, CancellationToken cancellationToken)
        => await dbSet
            .Where(d => d.DeletedAt == null)
            .Include(d => d.Users)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
}