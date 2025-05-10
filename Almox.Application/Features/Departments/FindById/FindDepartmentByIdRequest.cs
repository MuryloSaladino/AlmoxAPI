using MediatR;

namespace Almox.Application.Features.Departments.FindById;

public sealed record FindDepartmentByIdRequest(
    Guid Id
) : IRequest<FindDepartmentByIdResponse>;