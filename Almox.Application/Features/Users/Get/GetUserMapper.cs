using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Users.Get;

public class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<User, GetUserResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
    }
}