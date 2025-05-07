namespace Almox.Application.Features.Departments.Create;

public sealed record CreateDepartmentResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);
