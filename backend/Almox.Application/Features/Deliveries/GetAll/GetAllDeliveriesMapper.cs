using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Deliveries.GetAll;

public class GetAllDeliveriesMapper : Profile
{
    public GetAllDeliveriesMapper()
    {
        CreateMap<Delivery, GetAllDeliveriesResponse>();
    }
}