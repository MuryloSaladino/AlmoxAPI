using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.Create;

public class CreateRequestMapper : Profile
{
    public CreateRequestMapper()
    {
        CreateMap<Request, CreateRequestResponse>();
    }
}