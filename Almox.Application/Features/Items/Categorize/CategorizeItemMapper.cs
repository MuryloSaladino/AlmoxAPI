using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Items.Categorize;

public class CategorizeItemMapper : Profile
{
    public CategorizeItemMapper()
    {
        CreateMap<Category, CategorizeItemResponseCategory>();
        CreateMap<Item, CategorizeItemResponse>();
    }
}