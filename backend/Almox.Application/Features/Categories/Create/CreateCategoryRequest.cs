using MediatR;

namespace Almox.Application.Features.Categories.Create;

public sealed record CreateCategoryRequest(
    string Name
) : IRequest<CreateCategoryResponse>;