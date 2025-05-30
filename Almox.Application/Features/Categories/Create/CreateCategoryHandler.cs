using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Categories.Create;

public class CreateCategoryHandler(
    ICategoriesRepository categoriesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    public async Task<CreateCategoryResponse> Handle(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);
        
        categoriesRepository.Create(category);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateCategoryResponse>(category);
    }
}