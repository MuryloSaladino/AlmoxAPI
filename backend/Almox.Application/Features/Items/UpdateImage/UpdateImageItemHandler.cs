using Almox.Application.Common.Exceptions;
using Almox.Application.Repository;
using Almox.Application.Repository.Images;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Items.UpdateImage;

public class UpdateImageItemHandler(
    IImagesRepository imageRepository,
    IItemsRepository itemsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateImageItemRequest, UpdateImageItemResponse>
{
    public async Task<UpdateImageItemResponse> Handle(
        UpdateImageItemRequest request, CancellationToken cancellationToken)
    {
        var item = await itemsRepository.Get(request.ItemId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);

        var url = await imageRepository.Save(request.File, request.FileName)
            ?? throw AppException.BadGateway(ExceptionMessages.BadGateway.Storage);

        await imageRepository.Delete(item.ImageUrl);
        
        item.ImageUrl = url;
        itemsRepository.Update(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateImageItemResponse>(item);
    }
}