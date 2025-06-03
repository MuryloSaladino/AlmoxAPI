using MediatR;

namespace Almox.Application.Features.Departments.Count;

public sealed record CountDepartmentsRequest
    : IRequest<CountDepartmentsResponse>;