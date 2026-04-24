
using Application.Business.Departments.Requests;
using FluentValidation;

namespace Application.Business.Departments.Validators;

public sealed class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
{
    public UpdateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.ImageUrl)
            .MaximumLength(255);
    }
}
