using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.GetAll;

public class FindItemsHandler(
    IItemsRepository itemsRepository,
    IMapper mapper
) : IRequestHandler<GetAllItemsRequest, PaginatedResult<GetAllItemsResponse>>
{
    public async Task<PaginatedResult<GetAllItemsResponse>> Handle(
        GetAllItemsRequest request, CancellationToken cancellationToken)
    {
        var items = await itemsRepository.GetAll(request, cancellationToken);

        return mapper.Map<PaginatedResult<GetAllItemsResponse>>(items);
    }
}