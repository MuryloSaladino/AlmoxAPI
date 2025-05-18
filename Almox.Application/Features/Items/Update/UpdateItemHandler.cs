using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.ItemsRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemHandler(
    IItemsRepository itemsRepository,
    IUserSession userSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateItemRequest, UpdateItemResponse>
{
    private readonly IItemsRepository itemsRepository = itemsRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateItemResponse> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
    {
        if(!userSession.GetSessionOrThrow().IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var item = await itemsRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Item);

        if(request.Body.Name is string name)
            item.Name = name;
        if(request.Body.Quantity is int quantity)
            item.Quantity = quantity;

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateItemResponse>(item);
    }
}