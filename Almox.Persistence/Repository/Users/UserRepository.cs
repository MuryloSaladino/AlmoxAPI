using Microsoft.EntityFrameworkCore;
using Almox.Domain.Entities;
using Almox.Persistence.Context;
using Almox.Application.Repository.Users;
using Almox.Application.Repository;

namespace Almox.Persistence.Repository.Users;

public class UserRepository(
    AlmoxContext context
) : BaseRepository<User>(context), IUsersRepository
{
    public Task<User?> GetByUsernameOrEmail(
        string search, CancellationToken cancellationToken)
            => context.Set<User>()
                .Where(u => u.DeletedAt == null)
                .Where(u => u.Username == search || u.Email == search)
                .FirstOrDefaultAsync(cancellationToken);

    public async Task<PaginatedResult<User>> GetAll(
        UserFilters filters, CancellationToken cancellationToken)
    {
        var query = context.Set<User>()
            .AsQueryable()
            .Where(e => e.DeletedAt == null);

        if (filters.Username is string username)
            query = query.Where(u => EF.Functions.ILike(u.Username, $"%{username}%"));
        if (filters.Email is string email)
            query = query.Where(u => EF.Functions.ILike(u.Email, $"%{email}%"));

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .OrderBy(u => u.Username)
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);

        return new(filters.Page, filters.PageSize, maxPage, results);
    }
}