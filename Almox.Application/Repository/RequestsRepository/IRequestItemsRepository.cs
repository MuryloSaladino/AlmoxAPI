using Almox.Domain.Entities;

namespace Almox.Application.Repository.RequestsRepository;

public interface IRequestItemsRepository
{
    void Create(RequestItem requestItem);
    void Delete(Guid itemId, Guid deliveryId);
}