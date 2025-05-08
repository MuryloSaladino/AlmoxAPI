using Almox.Application.Repository;
using Almox.Application.Repository.ItemsRepository;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Create;

public class CreateItemHandler(
    IItemsRepository itemsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateItemRequest, CreateItemResponse>
{
    private readonly IItemsRepository itemsRepository = itemsRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var item = mapper.Map<Item>(request);
        itemsRepository.Create(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateItemResponse>(item);
    }
}