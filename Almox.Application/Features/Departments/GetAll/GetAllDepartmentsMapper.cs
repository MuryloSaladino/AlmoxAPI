using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Departments.GetAll;

public class GetAllDepartmentsMapper : Profile
{
    public GetAllDepartmentsMapper()
    {
        CreateMap<Department, GetAllDepartmentsResponse>()
            .ConstructUsing(d => new GetAllDepartmentsResponse(
                d.Id,
                d.CreatedAt,
                d.UpdatedAt,
                d.DeletedAt,
                d.Name,
                d.Users.Count
            ));
    }
}