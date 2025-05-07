namespace Almox.Application.Features.Departments.FindById;

public sealed record FindDepartmentByIdResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);