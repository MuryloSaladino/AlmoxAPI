using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.DepartmentsRepository;
using Almox.Domain.Common.Messages;
using MediatR;

namespace Almox.Application.Features.Departments.Delete;

public class DeleteDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IUserSession userSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteDepartmentResponse> Handle(
        DeleteDepartmentRequest request, CancellationToken cancellationToken)
    {
        if(!userSession.GetSessionOrThrow().IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var department = await departmentRepository.Get(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Department);

        departmentRepository.Delete(department);
        
        await unitOfWork.Save(cancellationToken);

        return new DeleteDepartmentResponse();
    }
}