using MediatR;

namespace Almox.Application.Features.Departments.Create;

public sealed record CreateDepartmentRequest(
    string Name
) : IRequest<CreateDepartmentResponse>;
