namespace Almox.Application.Features.Departments.Find;

public sealed record FindDepartmentResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);