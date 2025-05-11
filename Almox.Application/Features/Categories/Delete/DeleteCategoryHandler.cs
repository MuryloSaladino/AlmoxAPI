using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.CategoriesRepository;
using Almox.Domain.Common.Messages;
using MediatR;

namespace Almox.Application.Features.Categories.Delete;

public class DeleteCategoryHandler(
    ICategoriesRepository categoriesRepository,
    IUserSession userSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
{
    private readonly ICategoriesRepository categoriesRepository = categoriesRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        if(!userSession.GetSession().IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var category = await categoriesRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Category);
        
        categoriesRepository.Delete(category);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteCategoryResponse();
    }
}