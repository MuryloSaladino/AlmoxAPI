using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Categories.Find;

public class FindCategoriesMapper : Profile
{
    public FindCategoriesMapper()
    {
        CreateMap<Category, FindCategoriesResponse>();
    }
}