using Almox.Application.Repository.DepartmentsRepository;
using MediatR;

namespace Almox.Application.Features.Departments.Find;

public sealed record FindDepartmentsRequest(
    DepartmentsQueryFilters Filters
) : IRequest<List<FindDepartmentsResponse>>;