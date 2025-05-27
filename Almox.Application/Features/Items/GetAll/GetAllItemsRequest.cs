using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using MediatR;

namespace Almox.Application.Features.Items.GetAll;

public sealed record GetAllItemsRequest
    : ItemFilters, IRequest<PaginatedResult<GetAllItemsResponse>>;