
using Application.Business.Payments.Requests;
using FluentValidation;

namespace Application.Business.Payments.Validators;

public sealed class CreatePaymentRequestValidator : AbstractValidator<CreatePaymentRequest>
{
    public CreatePaymentRequestValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.PaymentMethod)
            .InclusiveBetween((byte)1, (byte)3);

        RuleFor(x => x.PaymentDate)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .When(x => x.PaymentDate.HasValue);
    }
}