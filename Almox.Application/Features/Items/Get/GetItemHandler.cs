using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.Get;

public class GetItemHandler(
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetItemRequest, GetItemResponse>
{
    public async Task<GetItemResponse> Handle(
        GetItemRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var item = await itemsRepository.Get(request.ItemId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);

        return mapper.Map<GetItemResponse>(item);
    }
}