using Almox.Application.Common.Session;
using Almox.Application.Repository.Categories;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Categories.Find;

public class FindCategoriesHandler(
    ICategoriesRepository categoriesRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindCategoriesRequest, List<FindCategoriesResponse>>
{
    public async Task<List<FindCategoriesResponse>> Handle(
        FindCategoriesRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var categories = await categoriesRepository.GetAll(cancellationToken);

        return mapper.Map<List<FindCategoriesResponse>>(categories);
    }
}