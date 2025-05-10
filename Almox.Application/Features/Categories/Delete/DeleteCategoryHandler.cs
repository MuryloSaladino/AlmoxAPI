using Almox.Application.Common.Exceptions;
using Almox.Application.Repository;
using Almox.Application.Repository.CategoriesRepository;
using MediatR;

namespace Almox.Application.Features.Categories.Delete;

public class DeleteCategoryHandler(
    ICategoriesRepository categoriesRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
{
    private readonly ICategoriesRepository categoriesRepository = categoriesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await categoriesRepository.Get(request.Id, cancellationToken)
            ?? throw new AppException("Category Not Found", AppExceptionCode.NotFound);
        
        categoriesRepository.Delete(category);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteCategoryResponse();
    }
}