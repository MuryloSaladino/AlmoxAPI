using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Create;

public class CreateItemHandler(
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateItemRequest, CreateItemResponse>
{
    public async Task<CreateItemResponse> Handle(
        CreateItemRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var item = mapper.Map<Item>(request);
        
        itemsRepository.Create(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateItemResponse>(item);
    }
}