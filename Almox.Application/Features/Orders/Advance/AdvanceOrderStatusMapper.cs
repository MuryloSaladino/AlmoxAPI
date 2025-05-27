using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Advance;

public class AdvanceOrderMapper : Profile
{
    public AdvanceOrderMapper()
    {
        CreateMap<Order, AdvanceOrderResponse>();
    }
}