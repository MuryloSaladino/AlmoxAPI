using Almox.Application.Common.Exceptions;
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
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateItemRequest, UpdateItemResponse>
{
    public async Task<UpdateItemResponse> Handle(
        UpdateItemRequest request, CancellationToken cancellationToken)
    {
        var item = await itemsRepository.Get(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);

        item.Name = request.Name;
        item.Stock = request.Stock;
        item.Price = request.Price;
        item.Description = request.Description;

        item.Categories = await categoriesRepository.GetAll(request.CategoryIds, cancellationToken);

        itemsRepository.Update(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateItemResponse>(item);
    }
}