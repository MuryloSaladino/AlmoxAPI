using Almox.Application.Common.Session;
using Almox.Application.Repository.Departments;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Find;

public class FindDepartmentsHandler(
    IDepartmentRepository departmentRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindDepartmentsRequest, List<FindDepartmentsResponse>>
{
    public async Task<List<FindDepartmentsResponse>> Handle(
        FindDepartmentsRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var departments = await departmentRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindDepartmentsResponse>>(departments);
    }
}