namespace Almox.Application.Features.Departments.FindById;

public sealed record FindDepartmentByIdResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    List<FindDepartmentByIdUserPresenter> Users,
    string Name
);

public record FindDepartmentByIdUserPresenter(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    bool IsAdmin
);