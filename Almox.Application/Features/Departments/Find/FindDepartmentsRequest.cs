using Almox.Application.Repository.Departments;
using MediatR;

namespace Almox.Application.Features.Departments.Find;

public sealed record FindDepartmentsRequest(
    DepartmentsQueryFilters Filters
) : IRequest<List<FindDepartmentsResponse>>;