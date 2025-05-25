using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Departments;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Create;

public class CreateDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
{
    public async Task<CreateDepartmentResponse> Handle(
        CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var department = mapper.Map<Department>(request);
        departmentRepository.Create(department);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateDepartmentResponse>(department);
    }
}