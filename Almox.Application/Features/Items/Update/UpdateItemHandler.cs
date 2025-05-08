using Almox.Application.Common.Exceptions;
using Almox.Application.Repository;
using Almox.Application.Repository.ItemsRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemHandler(
    IItemsRepository itemsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateItemRequest, UpdateItemResponse>
{
    private readonly IItemsRepository itemsRepository = itemsRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateItemResponse> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
    {
        var item = await itemsRepository.Get(Guid.Parse(request.Id), cancellationToken)
            ?? throw new AppException("Item not found", AppExceptionCode.NotFound);

        if(!string.IsNullOrEmpty(request.Name))
            item.Name = request.Name;
        if(request.Quantity is not null)
            item.Quantity = (int) request.Quantity;

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateItemResponse>(item);
    }
}