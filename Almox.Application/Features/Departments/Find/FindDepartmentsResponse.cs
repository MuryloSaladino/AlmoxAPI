namespace Almox.Application.Features.Departments.Find;

public sealed record FindDepartmentsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);