using Almox.Application.Repository.Departments;
using MediatR;

namespace Almox.Application.Features.Departments.GetAll;

public sealed record GetAllDepartmentsRequest(
    DepartmentFilters Filters
) : IRequest<List<GetAllDepartmentsResponse>>;