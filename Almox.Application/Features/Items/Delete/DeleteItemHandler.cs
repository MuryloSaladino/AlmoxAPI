using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.ItemsRepository;
using Almox.Domain.Common.Messages;
using MediatR;

namespace Almox.Application.Features.Items.Delete;

public class DeleteItemHandler(
    IItemsRepository categoriesRepository,
    IUserSession userSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
{
    private readonly IItemsRepository categoriesRepository = categoriesRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
    {
        if(!userSession.GetSession().IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var category = await categoriesRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Item);
        
        categoriesRepository.Delete(category);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteItemResponse();
    }
}