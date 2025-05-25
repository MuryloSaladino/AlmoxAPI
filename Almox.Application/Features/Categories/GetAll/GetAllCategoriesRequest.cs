using MediatR;

namespace Almox.Application.Features.Categories.GetAll;

public sealed record GetAllCategoriesRequest() 
    : IRequest<List<GetAllCategoriesResponse>>;