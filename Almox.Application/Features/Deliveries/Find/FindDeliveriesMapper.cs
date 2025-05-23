using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Deliveries.Find;

public class FindDeliveriesMapper : Profile
{
    public FindDeliveriesMapper()
    {
        CreateMap<Delivery, FindDeliveriesResponse>();
    }
}