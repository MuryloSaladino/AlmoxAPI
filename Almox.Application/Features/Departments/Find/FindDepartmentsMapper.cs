using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Departments.Find;

public class FindDepartmentsMapper : Profile
{
    public FindDepartmentsMapper()
    {
        CreateMap<Department, FindDepartmentsResponse>();
    }
}