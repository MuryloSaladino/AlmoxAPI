using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Departments.FindById;

public class FindDepartmentByIdMapper : Profile
{
    public FindDepartmentByIdMapper()
    {
        CreateMap<Department, FindDepartmentByIdResponse>();
        CreateMap<User, FindDepartmentByIdResponseUser>();
    }
}