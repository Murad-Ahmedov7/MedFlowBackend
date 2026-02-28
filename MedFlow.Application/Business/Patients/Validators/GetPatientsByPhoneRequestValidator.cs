

using Application.Business.Patients.Requests;
using FluentValidation;


namespace Application.Business.Patients.Validators;

public sealed class GetPatientsByPhoneRequestValidator : AbstractValidator<GetPatientsByPhoneRequest>
{
    public GetPatientsByPhoneRequestValidator()
    {
        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20)
            .Must(p => p.Count(char.IsDigit) >= 9 && p.Count(char.IsDigit) <= 15)
            .Matches(@"^[0-9+\-\s()]+$");
    }
}


