using Application.Business.Patients.Requests;
using FluentValidation;

namespace Application.Business.Patients.Validators
{

    public sealed class GetPatientsByNameRequestValidator
        : AbstractValidator<GetPatientsByNameRequest>
    {
        public GetPatientsByNameRequestValidator()
        {
            RuleFor(x => x)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x.FirstName) ||
                    !string.IsNullOrWhiteSpace(x.LastName))
                .WithMessage("Ən azı ad və ya soyad göndərilməlidir.");

            When(x => !string.IsNullOrWhiteSpace(x.FirstName), () =>
            {
                RuleFor(x => x.FirstName!)
                    .MinimumLength(3)
                    .MaximumLength(50);
            });

            When(x => !string.IsNullOrWhiteSpace(x.LastName), () =>
            {
                RuleFor(x => x.LastName!)
                    .MinimumLength(3)
                    .MaximumLength(50);
            });
        }
    }
}


