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
    IUserSession userSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CategorizeItemRequest, CategorizeItemResponse>
{
    private readonly ICategoriesRepository categoriesRepository = categoriesRepository;
    private readonly IItemsRepository itemsRepository = itemsRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CategorizeItemResponse> Handle(CategorizeItemRequest request, CancellationToken cancellationToken)
    {
        if(!userSession.GetSessionOrThrow().IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var category = await categoriesRepository.Get(request.CategoryId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Category);
        var item = await itemsRepository.Get(request.ItemId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Item);

        item.Categories.Add(category);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CategorizeItemResponse>(item);
    }
}