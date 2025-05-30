using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Auth.GetLoggedUser;

public class GetLoggedUserMapper : Profile
{
    public GetLoggedUserMapper()
    {
        CreateMap<User, GetLoggedUserResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
    }
}