using Almox.Application.Repository.ItemsRepository;
using MediatR;

namespace Almox.Application.Features.Items.Find;

public sealed record FindItemsRequest(
    ItemsQueryFilters Filters
) : IRequest<List<FindItemsResponse>>;