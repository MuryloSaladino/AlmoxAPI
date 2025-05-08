using MediatR;

namespace Almox.Application.Features.Categories.Delete;

public sealed record DeleteCategoryRequest(
    string Id
) : IRequest<DeleteCategoryResponse>;
