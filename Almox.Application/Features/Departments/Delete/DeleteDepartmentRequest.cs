using MediatR;

namespace Almox.Application.Features.Departments.Delete;

public sealed record DeleteDepartmentRequest(
    Guid Id
) : IRequest<DeleteDepartmentResponse>;