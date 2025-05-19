using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.DepartmentsRepository;
using Almox.Domain.Common.Messages;
using MediatR;

namespace Almox.Application.Features.Departments.Delete;

public class DeleteDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteDepartmentResponse> Handle(
        DeleteDepartmentRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var department = await departmentRepository.Get(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Department);

        departmentRepository.Delete(department);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteDepartmentResponse();
    }
}