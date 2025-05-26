using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemHandler(
    ICategoriesRepository categoriesRepository,
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateItemRequest, UpdateItemResponse>
{
    public async Task<UpdateItemResponse> Handle(
        UpdateItemRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetStaffSessionOrThrow();

        var item = await itemsRepository.Get(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);

        item.Name = request.Props.Name;
        item.Stock = request.Props.Stock;
        item.Price = request.Props.Price;
        item.Description = request.Props.Description;

        var categoryFilters = new CategoryFilters(request.Props.CategoryIds);
        item.Categories = await categoriesRepository.GetAll(categoryFilters, cancellationToken);

        itemsRepository.Update(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateItemResponse>(item);
    }
}