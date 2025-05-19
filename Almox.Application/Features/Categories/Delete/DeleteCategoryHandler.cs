using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.CategoriesRepository;
using Almox.Domain.Common.Messages;
using MediatR;

namespace Almox.Application.Features.Categories.Delete;

public class DeleteCategoryHandler(
    ICategoriesRepository categoriesRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
{
    private readonly ICategoriesRepository categoriesRepository = categoriesRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        if(!requestSession.GetSessionOrThrow().IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var category = await categoriesRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Category);
        
        categoriesRepository.Delete(category);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteCategoryResponse();
    }
}