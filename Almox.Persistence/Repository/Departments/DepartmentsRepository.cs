using Almox.Application.Repository.Departments;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Departments;

public class DepartmentsRepository(
    AlmoxContext context
) : BaseRepository<Department>(context), IDepartmentRepository
{
    public Task<List<Department>> GetAll(DepartmentFilters filters, CancellationToken cancellationToken)
        => context.Set<Department>()
            .Where(d => d.DeletedAt == null)
            .Where(d => filters.Name == null || EF.Functions.ILike(d.Name, $"%{filters.Name}%"))
            .Include(d => d.Users)
            .ToListAsync(cancellationToken);
}