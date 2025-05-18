using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.DepartmentsRepository;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.Create;

public class CreateDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IUserSession userSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IUserSession userSession = userSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateDepartmentResponse> Handle(
        CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        if(!userSession.GetSessionOrThrow().IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var department = mapper.Map<Department>(request);
        departmentRepository.Create(department);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateDepartmentResponse>(department);
    }
}