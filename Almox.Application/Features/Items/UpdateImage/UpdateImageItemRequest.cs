using MediatR;

namespace Almox.Application.Features.Items.UpdateImage;

public sealed record UpdateImageItemRequest(
    Guid ItemId,
    Stream File,
    string FileName
) : IRequest<UpdateImageItemResponse>;