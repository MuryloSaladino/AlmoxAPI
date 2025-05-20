using MediatR;

namespace Almox.Application.Features.Categories.Create;

public sealed record CreateCategoryRequest(
    string Name,
    string Description,
    string Color
) : IRequest<CreateCategoryResponse>;