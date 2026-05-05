

using Application.Business.Services.Requests;
using FluentValidation;

namespace Application.Business.Services.Validators
{
    public sealed class CreateServiceForDepartmentValidator : AbstractValidator<CreateServiceForDepartmentRequest>
    {
        public CreateServiceForDepartmentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.ImageUrl)
                .MaximumLength(255);
        }
    }
}
