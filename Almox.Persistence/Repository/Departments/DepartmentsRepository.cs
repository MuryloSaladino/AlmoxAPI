using Almox.Application.Repository;
using Almox.Application.Repository.Departments;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Repository.Departments;

public class DepartmentsRepository(
    AlmoxContext context
) : BaseRepository<Department>(context), IDepartmentRepository
{
    public async Task<PaginatedResult<Department>> GetAll(
        DepartmentFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<Department>()
            .AsQueryable()
            .Include(d => d.Users)
            .Where(e => e.DeletedAt == null);

        if (filters.Name is string name)
            query = query.Where(d => EF.Functions.ILike(d.Name, $"%{filters.Name}%"));

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .OrderBy(d => d.Name)
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);

        return new(filters.Page, filters.PageSize, maxPage, results);
    }
}