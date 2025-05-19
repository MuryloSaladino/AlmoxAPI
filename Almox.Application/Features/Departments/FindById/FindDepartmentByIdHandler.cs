using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.DepartmentsRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Departments.FindById;

public class FindDepartmentByIdHandler(
    IDepartmentRepository departmentRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindDepartmentByIdRequest, FindDepartmentByIdResponse>
{
    private readonly IDepartmentRepository departmentRepository = departmentRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<FindDepartmentByIdResponse> Handle(
        FindDepartmentByIdRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var department = await departmentRepository.GetWithUsers(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Department);

        return mapper.Map<FindDepartmentByIdResponse>(department);
    }
}