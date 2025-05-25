using Almox.Application.Repository.Items;
using MediatR;

namespace Almox.Application.Features.Items.Find;

public sealed record FindItemsRequest(
    ItemsQueryFilters Filters
) : IRequest<List<FindItemsResponse>>;