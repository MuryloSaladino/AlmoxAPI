using Almox.Application.Common.Session;
using Almox.Application.Repository.DepartmentsRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Find;

public class FindDepartmentsHandler(
    IDepartmentRepository departmentRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindDepartmentsRequest, List<FindDepartmentsResponse>>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindDepartmentsResponse>> Handle(
        FindDepartmentsRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var departments = await departmentRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindDepartmentsResponse>>(departments);
    }
}