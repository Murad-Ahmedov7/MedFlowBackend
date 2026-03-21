
using Application.Business.Prescriptions.Requests;
using FluentValidation;

namespace Application.Business.Prescriptions.Validators;

public sealed class CreatePrescriptionRequestValidator : AbstractValidator<CreatePrescriptionRequest>
{
    public CreatePrescriptionRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.ExaminationId)
            .NotEmpty();
    }
}
