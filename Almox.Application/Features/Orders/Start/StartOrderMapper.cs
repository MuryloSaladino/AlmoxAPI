using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Start;

public class StartOrderMapper : Profile
{
    public StartOrderMapper()
    {
        CreateMap<Order, StartOrderResponse>();
    }
}