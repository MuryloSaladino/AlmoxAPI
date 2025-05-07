using MediatR;

namespace Almox.Application.Features.Departments.Delete;

public sealed record DeleteDepartmentRequest(
    string Id
) : IRequest<DeleteDepartmentResponse>;