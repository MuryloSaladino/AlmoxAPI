using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Exceptions;
using MediatR;

namespace Almox.Application.Features.Items.Delete;

public class DeleteItemHandler(
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
{
    public async Task<DeleteItemResponse> Handle(
        DeleteItemRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetStaffSessionOrThrow();

        var item = await itemsRepository.Get(request.ItemId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);
        
        itemsRepository.Delete(item);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteItemResponse();
    }
}