

using Application.Business.Patients.Requests;
using FluentValidation;

namespace Application.Business.Patients.Validators;

public sealed class GetPatientByFinRequestValidator : AbstractValidator<GetPatientByFinRequest>
{
    public GetPatientByFinRequestValidator()
    {
        RuleFor(x => x.Fin.ToUpper())
            .NotEmpty()
            .Length(7, 10)
            .Matches("^[A-Z0-9]+$")
            .WithMessage("FIN must contain only uppercase letters and digits.");

    }
}

