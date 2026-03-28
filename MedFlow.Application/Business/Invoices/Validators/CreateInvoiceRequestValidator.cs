

using Application.Business.Invoices.Requests;
using FluentValidation;

namespace Application.Business.Invoices.Validators;

public class CreateInvoiceRequestValidator : AbstractValidator<CreateInvoiceRequest>
{
    public CreateInvoiceRequestValidator()
    {
        RuleFor(x => x.InvoiceItems)
            .NotEmpty()
            .WithMessage("At least one invoice item is required.")
            .Must(items => items.GroupBy(i => i.DepartmentServiceId)
            .All(g => g.Count() == 1)
            )
            .WithMessage("A service cannot be added more than once. Please check your list.");

        RuleForEach(x => x.InvoiceItems)
            .SetValidator(new InvoiceItemRequestValidator());
    }
}