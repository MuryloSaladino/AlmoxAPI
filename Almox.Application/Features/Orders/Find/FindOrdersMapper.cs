using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Find;

public class FindOrdersMapper : Profile
{
    public FindOrdersMapper()
    {
        CreateMap<Order, FindOrdersResponse>();
    }
}