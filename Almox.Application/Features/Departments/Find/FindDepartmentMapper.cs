using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Departments.Find;

public class FindDepartmentMapper : Profile
{
    public FindDepartmentMapper()
    {
        CreateMap<Department, FindDepartmentResponse>();
    }
}