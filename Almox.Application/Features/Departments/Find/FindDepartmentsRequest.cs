using MediatR;

namespace Almox.Application.Features.Departments.Find;

public sealed record FindDepartmentsRequest(
    string? Name
) : IRequest<List<FindDepartmentsResponse>>;