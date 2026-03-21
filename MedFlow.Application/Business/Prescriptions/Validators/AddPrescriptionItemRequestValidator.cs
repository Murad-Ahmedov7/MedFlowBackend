
using Application.Business.Prescriptions.Requests;
using FluentValidation;

namespace Application.Business.Prescriptions.Validators;

public sealed class AddPrescriptionItemRequestValidator : AbstractValidator<AddPrescriptionItemRequest>
{
    public AddPrescriptionItemRequestValidator()
    {
        RuleFor(x => x.MedicineId)
            .NotEmpty();

        RuleFor(x => x.Dose)
            .GreaterThan(0);

        RuleFor(x => x.DurationInDays)
            .GreaterThan(0);
   
        RuleFor(x => x.Frequency)
            .GreaterThan(0);
           
        RuleFor(x => x.UsageInstruction)
            .MaximumLength(100);
    }
}
