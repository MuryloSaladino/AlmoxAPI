using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Categories.Create;

public class CreateCategoryMapper : Profile
{
    public CreateCategoryMapper()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CreateCategoryResponse>();
    }
}