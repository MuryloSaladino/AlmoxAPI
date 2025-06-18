namespace Almox.Application.Features.Departments.Create;

public sealed record CreateDepartmentResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);
