using Almox.Application.Repository.Categories;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Categories.GetAll;

public class GetAllCategoriesHandler(
    ICategoriesRepository categoriesRepository,
    IMapper mapper
) : IRequestHandler<GetAllCategoriesRequest, List<GetAllCategoriesResponse>>
{
    public async Task<List<GetAllCategoriesResponse>> Handle(
        GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await categoriesRepository.GetAll(cancellationToken);

        return mapper.Map<List<GetAllCategoriesResponse>>(categories);
    }
}