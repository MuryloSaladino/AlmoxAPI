using Almox.Application.Common.Session;
using Almox.Application.Repository.Categories;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Categories.GetAll;

public class GetAllCategoriesHandler(
    ICategoriesRepository categoriesRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllCategoriesRequest, List<GetAllCategoriesResponse>>
{
    public async Task<List<GetAllCategoriesResponse>> Handle(
        GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var categories = await categoriesRepository.GetAll(cancellationToken);

        return mapper.Map<List<GetAllCategoriesResponse>>(categories);
    }
}