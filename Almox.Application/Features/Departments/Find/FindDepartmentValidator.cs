using FluentValidation;

namespace Almox.Application.Features.Departments.Find;

public class FindDepartmentValidator : AbstractValidator<FindDepartmentRequest>
{
    public FindDepartmentValidator()
    {
        RuleFor(d => d.Id).Must(id => Guid.TryParse(id, out _));
    }
}