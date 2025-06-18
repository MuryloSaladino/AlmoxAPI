using Almox.Application.Repository;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository;

public class UnitOfWork(AlmoxContext context) : IUnitOfWork
{
    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}