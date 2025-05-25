using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Departments;
using Almox.Domain.Common.Exceptions;
using MediatR;

namespace Almox.Application.Features.Departments.Delete;

public class DeleteDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
{
    public async Task<DeleteDepartmentResponse> Handle(
        DeleteDepartmentRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetAdminSessionOrThrow();

        var department = await departmentRepository.Get(request.DepartmentId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Department);

        departmentRepository.Delete(department);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteDepartmentResponse();
    }
}