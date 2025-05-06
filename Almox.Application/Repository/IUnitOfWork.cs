namespace Almox.Application.Repository;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}