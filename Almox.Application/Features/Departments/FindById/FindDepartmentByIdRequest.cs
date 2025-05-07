using MediatR;

namespace Almox.Application.Features.Departments.FindById;

public sealed record FindDepartmentByIdRequest(
    string Id
) : IRequest<FindDepartmentByIdResponse>;