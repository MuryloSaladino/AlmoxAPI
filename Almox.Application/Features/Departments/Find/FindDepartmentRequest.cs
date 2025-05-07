using MediatR;

namespace Almox.Application.Features.Departments.Find;

public sealed record FindDepartmentRequest(
    string Id
) : IRequest<FindDepartmentResponse>;