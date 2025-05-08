using Almox.Application.Repository.CategoriesRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Categories.Find;

public class FindCategoriesHandler(
    ICategoriesRepository categoriesRepository,
    IMapper mapper
) : IRequestHandler<FindCategoriesRequest, List<FindCategoriesResponse>>
{
    private readonly ICategoriesRepository categoriesRepository = categoriesRepository;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindCategoriesResponse>> Handle(FindCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await categoriesRepository.GetAll(cancellationToken);

        return mapper.Map<List<FindCategoriesResponse>>(categories);
    }
}