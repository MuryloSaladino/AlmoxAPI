using Almox.Application.Common.Exceptions;
using Almox.Application.Repository.DepartmentsRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.FindById;

public class FindDepartmentByIdHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<FindDepartmentByIdRequest, FindDepartmentByIdResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IMapper mapper = mapper;

    public async Task<FindDepartmentByIdResponse> Handle(
        FindDepartmentByIdRequest request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetWithUsers(Guid.Parse(request.Id), cancellationToken)
            ?? throw new AppException("Department not found", AppExceptionCode.NotFound);

        return mapper.Map<FindDepartmentByIdResponse>(department);
    }
}