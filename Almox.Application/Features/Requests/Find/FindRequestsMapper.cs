using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.Find;

public class FindRequestsMapper : Profile
{
    public FindRequestsMapper()
    {
        CreateMap<Request, FindRequestsResponse>();
    }
}