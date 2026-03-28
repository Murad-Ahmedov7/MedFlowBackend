
using Application.Business.Invoices.Requests;
using FluentValidation;

namespace Application.Business.Invoices.Validators;

public class InvoiceItemRequestValidator : AbstractValidator<InvoiceItemRequest>
{
    public InvoiceItemRequestValidator()
    {
       
        RuleFor(x => x.DepartmentServiceId)
            .NotEmpty().WithMessage("ServiceId is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}
