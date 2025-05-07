using Almox.Application.Common.Exceptions;
using Almox.Application.Repository;
using Almox.Application.Repository.DepartmentsRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Find;

public class FindDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<FindDepartmentRequest, FindDepartmentResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IMapper mapper = mapper;

    public async Task<FindDepartmentResponse> Handle(
        FindDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.Get(Guid.Parse(request.Id), cancellationToken)
            ?? throw new AppException("Department not found", AppExceptionCode.NotFound);

        return mapper.Map<FindDepartmentResponse>(department);
    }
}