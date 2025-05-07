using Almox.Application.Common.Exceptions;
using Almox.Application.Repository;
using Almox.Application.Repository.DepartmentsRepository;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Delete;

public class DeleteDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteDepartmentResponse> Handle(
        DeleteDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.Get(Guid.Parse(request.Id), cancellationToken)
            ?? throw new AppException("Department not found", AppExceptionCode.NotFound);

        departmentRepository.Delete(department);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteDepartmentResponse();
    }
}