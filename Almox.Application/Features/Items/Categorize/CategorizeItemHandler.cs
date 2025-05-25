using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Categorize;

public class CategorizeItemHandler(
    ICategoriesRepository categoriesRepository,
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CategorizeItemRequest, CategorizeItemResponse>
{
    public async Task<CategorizeItemResponse> Handle(
        CategorizeItemRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var category = await categoriesRepository.Get(request.CategoryId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Category);
            
        var item = await itemsRepository.Get(request.ItemId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);

        item.Categories.Add(category);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CategorizeItemResponse>(item);
    }
}