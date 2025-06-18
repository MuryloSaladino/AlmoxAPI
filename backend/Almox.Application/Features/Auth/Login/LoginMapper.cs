using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Auth.Login;

public class LoginMapper : Profile
{
    public LoginMapper()
    {
        CreateMap<User, LoginUserPresenter>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
    }
}