using FluentValidation;

namespace Almox.Application.Features.Departments.Create;

public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentRequest>
{
    public CreateDepartmentValidator()
    {
        RuleFor(d => d.Name).NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}