

using Application.Business.Patients.Requests;
using FluentValidation;

namespace Application.Business.Patients.Validators;

public sealed class UpdatePatientRequestValidator : AbstractValidator<UpdatePatientRequest>
{
    public UpdatePatientRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Fin.ToUpper())
            .NotEmpty()
            .Length(7, 10)
            .Matches("^[A-Z0-9]+$")
            .WithMessage("FIN must contain only uppercase letters and digits.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20)
            .Must(p => p.Count(char.IsDigit) >= 9 && p.Count(char.IsDigit) <= 15)
            .Matches(@"^[0-9+\-\s()]+$");

        RuleFor(x => x.Address)
            .MaximumLength(255);

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Today);

        RuleFor(x => x.Gender)
            .IsInEnum()
            .WithMessage("Gender is invalid");

        RuleFor(x => x.BloodGroup)
            .IsInEnum()
            .WithMessage("Blood group is invalid");

        RuleFor(x => x.Address)
            .MaximumLength(255);
    }
}
