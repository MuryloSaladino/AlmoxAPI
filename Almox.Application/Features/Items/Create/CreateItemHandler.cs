using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using Almox.Application.Repository.Items;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Create;

public class CreateItemHandler(
    ICategoriesRepository categoriesRepository,
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateItemRequest, CreateItemResponse>
{
    public async Task<CreateItemResponse> Handle(
        CreateItemRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetStaffSessionOrThrow();

        var item = mapper.Map<Item>(request);

        item.Categories = await categoriesRepository.GetAll(request.CategoryIds, cancellationToken);

        itemsRepository.Create(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateItemResponse>(item);
    }
}