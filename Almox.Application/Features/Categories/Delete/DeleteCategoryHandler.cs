using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Categories;
using Almox.Domain.Common.Exceptions;
using MediatR;

namespace Almox.Application.Features.Categories.Delete;

public class DeleteCategoryHandler(
    ICategoriesRepository categoriesRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
{
    public async Task<DeleteCategoryResponse> Handle(
        DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetStaffSessionOrThrow();

        var category = await categoriesRepository.Get(request.CategoryId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Category);
        
        categoriesRepository.Delete(category);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteCategoryResponse();
    }
}