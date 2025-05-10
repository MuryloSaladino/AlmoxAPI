using Almox.Application.Repository;
using Almox.Application.Repository.RequestItemsRepository;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Requests.AddItem;

public class AddItemToRequestHandler(
    IRequestItemsRepository requestItemsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<AddItemToRequestRequest, AddItemToRequestResponse>
{
    private readonly IRequestItemsRepository requestItemsRepository = requestItemsRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<AddItemToRequestResponse> Handle(AddItemToRequestRequest request, CancellationToken cancellationToken)
    {
        var itemAddition = mapper.Map<RequestItem>(request);
        requestItemsRepository.Create(itemAddition);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AddItemToRequestResponse>(itemAddition);
    }
}