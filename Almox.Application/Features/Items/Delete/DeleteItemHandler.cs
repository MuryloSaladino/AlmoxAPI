using Almox.Application.Common.Exceptions;
using Almox.Application.Repository;
using Almox.Application.Repository.ItemsRepository;
using MediatR;

namespace Almox.Application.Features.Items.Delete;

public class DeleteItemHandler(
    IItemsRepository categoriesRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
{
    private readonly IItemsRepository categoriesRepository = categoriesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
    {
        var category = await categoriesRepository.Get(request.Id, cancellationToken)
            ?? throw new AppException("Item Not Found", AppExceptionCode.NotFound);
        
        categoriesRepository.Delete(category);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteItemResponse();
    }
}