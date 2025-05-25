using Almox.Application.Common.Session;
using Almox.Application.Repository.Items;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.GetAll;

public class FindItemsHandler(
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllItemsRequest, List<GetAllItemsResponse>>
{
    public async Task<List<GetAllItemsResponse>> Handle(
        GetAllItemsRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var items = await itemsRepository.GetAll(request.Filters, cancellationToken);

        return mapper.Map<List<GetAllItemsResponse>>(items);
    }
}