using Almox.Application.Common.Session;
using Almox.Application.Repository.Departments;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.GetAll;

public class GetAllDepartmentsHandler(
    IDepartmentRepository departmentRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllDepartmentsRequest, List<GetAllDepartmentsResponse>>
{
    public async Task<List<GetAllDepartmentsResponse>> Handle(
        GetAllDepartmentsRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetStaffSessionOrThrow();

        var departments = await departmentRepository.GetAll(request.Filters, cancellationToken);

        return mapper.Map<List<GetAllDepartmentsResponse>>(departments);
    }
}