using Almox.Application.Repository;
using Almox.Application.Repository.DepartmentsRepository;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Create;

public class CreateDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateDepartmentResponse> Handle(
        CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = mapper.Map<Department>(request);
        departmentRepository.Create(department);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateDepartmentResponse>(department);
    }
}