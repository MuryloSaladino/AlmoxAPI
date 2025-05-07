using FluentValidation;

namespace Almox.Application.Features.Departments.Delete;

public class DeleteDepartmentValidator : AbstractValidator<DeleteDepartmentRequest>
{
    public DeleteDepartmentValidator()
    {
        RuleFor(d => d.Id).Must(id => Guid.TryParse(id, out _));
    }
}