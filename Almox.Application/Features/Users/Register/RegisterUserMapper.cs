using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Users.Register;

public sealed class RegisterUserMapper : Profile
{
    public RegisterUserMapper()
    {
        CreateMap<RegisterUserRequest, User>();
        CreateMap<User, RegisterUserResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(u => u.Department.Name));
    }
}