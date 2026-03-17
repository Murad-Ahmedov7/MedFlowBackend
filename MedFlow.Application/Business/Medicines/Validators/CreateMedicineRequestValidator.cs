
using Application.Business.Medicines.Requests;
using FluentValidation;


namespace Application.Business.Medicines.Validators;
public sealed class CreateMedicineRequestValidator : AbstractValidator<CreateMedicineRequest>
{
    public CreateMedicineRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.Form)
            .InclusiveBetween((byte)1, (byte)8);

        RuleFor(x => x.Unit)
            .InclusiveBetween((byte)1, (byte)5);
    }
}