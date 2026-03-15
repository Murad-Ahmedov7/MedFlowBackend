

using Application.Business.Examinations.Requests;
using FluentValidation;

namespace Application.Business.Examinations.Validators;
public sealed class CreateExaminatonRequestValidator : AbstractValidator<CreateExaminationRequest>
{
    public CreateExaminatonRequestValidator()
    {
        RuleFor(x=>x.AppointmentId)
            .NotEmpty();

        RuleFor(x => x.Complaint)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(500);

        RuleFor(x => x.Diagnosis)
         .NotEmpty()
         .MinimumLength(3)
         .MaximumLength(500);

        RuleFor(x => x.Notes)
            .MaximumLength(1000);

        RuleFor(x => x.Temperature)
            .InclusiveBetween(30, 45);

        RuleFor(x => x.BloodPressureSystolic)
            .GreaterThan(x => x.BloodPressureDiastolic)
            .WithMessage("Systolic pressure should be greater than diastolic.");


        RuleFor(x => x.Pulse)
            .InclusiveBetween(30, 220)
            .When(x => x.Pulse.HasValue);


        RuleFor(x => x.Weight)
            .InclusiveBetween(1, 500)
            .When(x => x.Weight.HasValue);

        RuleFor(x => x.Height)
            .InclusiveBetween(30, 250)
            .When(x => x.Height.HasValue);

    }
}

