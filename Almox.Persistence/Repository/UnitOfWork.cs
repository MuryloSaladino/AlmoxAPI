using Almox.Application.Repository;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository;

public class UnitOfWork(AlmoxContext ctx) : IUnitOfWork
{
    private readonly AlmoxContext context = ctx;
    
    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}