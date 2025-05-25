namespace Almox.Application.Features.Departments.GetAll;

public sealed record GetAllDepartmentsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);