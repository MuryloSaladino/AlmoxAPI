using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using MediatR;

namespace Almox.Application.Features.Categories.GetAll;

public sealed record GetAllCategoriesRequest 
    : CategoryFilters, IRequest<PaginatedResult<GetAllCategoriesResponse>>;