using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemHandler(
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateItemRequest, UpdateItemResponse>
{
    public async Task<UpdateItemResponse> Handle(
        UpdateItemRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var item = await itemsRepository.Get(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);

        item.Name = request.Props.Name;
        item.Quantity = request.Props.Quantity;
        item.ImageUrl = request.Props.ImageUrl;

        itemsRepository.Update(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateItemResponse>(item);
    }
}