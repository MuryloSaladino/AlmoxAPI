using Almox.Application.Repository.DepartmentsRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Find;

public class FindDepartmentsHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<FindDepartmentsRequest, List<FindDepartmentsResponse>>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindDepartmentsResponse>> Handle(
        FindDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var departments = await departmentRepository.GetByName(request.Name, cancellationToken);

        return mapper.Map<List<FindDepartmentsResponse>>(departments);
    }
}