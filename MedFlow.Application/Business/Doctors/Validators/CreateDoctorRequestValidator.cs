

using Application.Business.Doctors.Requests;
using FluentValidation;

namespace Application.Business.Doctors.Validators;

public sealed class CreateDoctorRequestValidator : AbstractValidator<CreateDoctorRequest>
{
    public CreateDoctorRequestValidator()
    {
        // AUTH
        RuleFor(x => x.FullName)
           .NotEmpty()
           .MinimumLength(3)
           .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20)
            .Must(p => p.Count(char.IsDigit) >= 9 && p.Count(char.IsDigit) <= 15)
            .Matches(@"^[0-9+\-\s()]+$");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(255);

        RuleFor(x => x)
            .Must(x => x.Password == x.ConfirmPassword)
            .WithMessage("Passwords do not match.");

        // DOCTOR

        RuleFor(x => x.DepartmentId)
            .NotEmpty();

        RuleFor(x => x.Specialty)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.ImageUrl)
            .MaximumLength(255);
    }
}

