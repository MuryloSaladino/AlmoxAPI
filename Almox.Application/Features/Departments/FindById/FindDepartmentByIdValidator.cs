using FluentValidation;

namespace Almox.Application.Features.Departments.FindById;

public class FindDepartmentByIdValidator : AbstractValidator<FindDepartmentByIdRequest>
{
    public FindDepartmentByIdValidator()
    {
        RuleFor(d => d.Id).Must(id => Guid.TryParse(id, out _));
    }
}