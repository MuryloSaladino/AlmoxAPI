using MediatR;

namespace Almox.Application.Features.Categories.Delete;

public sealed record DeleteCategoryRequest(
    Guid Id
) : IRequest<DeleteCategoryResponse>;
