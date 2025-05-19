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
    private readonly IItemsRepository itemsRepository = itemsRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindItemsResponse>> Handle(
        FindItemsRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var items = await itemsRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindItemsResponse>>(items);
    }
}