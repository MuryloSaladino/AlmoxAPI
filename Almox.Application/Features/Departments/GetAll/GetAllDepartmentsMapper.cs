using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Departments.GetAll;

public class GetAllDepartmentsMapper : Profile
{
    public GetAllDepartmentsMapper()
    {
        CreateMap<Department, GetAllDepartmentsResponse>()
            .ForCtorParam("UserCount", opt => opt.MapFrom(d => d.Users.Count));
    }
}