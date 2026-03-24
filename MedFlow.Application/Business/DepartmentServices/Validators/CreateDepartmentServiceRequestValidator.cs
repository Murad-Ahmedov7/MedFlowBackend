

using Application.Business.DepartmentServices.Requests;
using FluentValidation;

namespace Application.Business.DepartmentServices.Validators;

public sealed class CreateDepartmentServiceRequestValidator: AbstractValidator<CreateDepartmentServiceRequest>
{
    public CreateDepartmentServiceRequestValidator()
    {
        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("DepartmentId is required");

        RuleFor(x => x.ServiceId)
            .NotEmpty()
            .WithMessage("ServiceId is required");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}
