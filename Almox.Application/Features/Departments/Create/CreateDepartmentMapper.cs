using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Departments.Create;

public class CreateDepartmentMapper : Profile
{
    public CreateDepartmentMapper()
    {
        CreateMap<CreateDepartmentRequest, Department>();
        CreateMap<Department, CreateDepartmentResponse>();
    }
}