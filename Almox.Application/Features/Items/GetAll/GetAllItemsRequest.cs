using Almox.Application.Repository.Items;
using MediatR;

namespace Almox.Application.Features.Items.GetAll;

public sealed record GetAllItemsRequest(
    ItemFilters Filters
) : IRequest<List<GetAllItemsResponse>>;