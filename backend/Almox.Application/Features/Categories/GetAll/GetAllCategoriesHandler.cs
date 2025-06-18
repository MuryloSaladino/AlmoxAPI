using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Categories.GetAll;

public class GetAllCategoriesHandler(
    ICategoriesRepository categoriesRepository,
    IMapper mapper
) : IRequestHandler<GetAllCategoriesRequest, PaginatedResult<GetAllCategoriesResponse>>
{
    public async Task<PaginatedResult<GetAllCategoriesResponse>> Handle(
        GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await categoriesRepository.GetAll(request, cancellationToken);

        return mapper.Map<PaginatedResult<GetAllCategoriesResponse>>(categories);
    }
}