using MediatR;

namespace Almox.Application.Features.Categories.Find;

public sealed record FindCategoriesRequest() 
    : IRequest<List<FindCategoriesResponse>>;