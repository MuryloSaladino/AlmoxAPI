using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Users.GetAll;

public class GetAllUsersMapper : Profile
{
    public GetAllUsersMapper()
    {
        CreateMap<User, GetAllUsersResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
    }
}