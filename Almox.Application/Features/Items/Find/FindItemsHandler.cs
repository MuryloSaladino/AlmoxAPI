using Almox.Application.Common.Session;
using Almox.Application.Repository.ItemsRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Find;

public class FindItemsHandler(
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindItemsRequest, List<FindItemsResponse>>
{
    public async Task<List<FindItemsResponse>> Handle(
        FindItemsRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var items = await itemsRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindItemsResponse>>(items);
    }
}