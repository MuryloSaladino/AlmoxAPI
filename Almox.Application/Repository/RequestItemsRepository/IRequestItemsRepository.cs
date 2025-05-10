using Almox.Domain.Entities;

namespace Almox.Application.Repository.RequestItemsRepository;

public interface IRequestItemsRepository
{
    void Create(RequestItem requestItem);
    void Delete(Guid itemId, Guid deliveryId);
}