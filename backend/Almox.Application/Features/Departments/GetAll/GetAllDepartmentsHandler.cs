using Almox.Application.Repository;
using Almox.Application.Repository.Departments;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.GetAll;

public class GetAllDepartmentsHandler(
    IDepartmentsRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<GetAllDepartmentsRequest, PaginatedResult<GetAllDepartmentsResponse>>
{
    public async Task<PaginatedResult<GetAllDepartmentsResponse>> Handle(
        GetAllDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var departments = await departmentRepository.GetAll(request, cancellationToken);

        return mapper.Map<PaginatedResult<GetAllDepartmentsResponse>>(departments);
    }
}