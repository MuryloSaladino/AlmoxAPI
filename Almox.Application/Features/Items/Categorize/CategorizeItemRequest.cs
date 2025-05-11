using MediatR;

namespace Almox.Application.Features.Items.Categorize;

public sealed record CategorizeItemRequest(
    Guid ItemId,
    Guid CategoryId
) : IRequest<CategorizeItemResponse>;