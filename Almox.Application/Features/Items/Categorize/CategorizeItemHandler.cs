using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.CategoriesRepository;
using Almox.Application.Repository.ItemsRepository;
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
    private readonly ICategoriesRepository categoriesRepository = categoriesRepository;
    private readonly IItemsRepository itemsRepository = itemsRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

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