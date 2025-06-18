using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Categories.GetAll;

public class GetAllCategoriesMapper : Profile
{
    public GetAllCategoriesMapper()
    {
        CreateMap<Category, GetAllCategoriesResponse>();
    }
}