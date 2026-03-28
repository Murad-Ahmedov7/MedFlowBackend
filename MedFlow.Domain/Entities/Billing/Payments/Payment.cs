
using Domain.Entities.Base;
using Domain.Entities.Billing.Invoices;
using Domain.Entities.Billing.Payments.Enums;


namespace Domain.Entities.Billing.Payments;

public class Payment : BaseEntity
{
    private Payment()
    {

    }
    public Payment(Guid invoiceId, decimal amount, PaymentMethod paymentMethod, DateTime paymentDate)
    {
        InvoiceId = invoiceId;
        Amount = amount;
        PaymentMethod = paymentMethod;
        PaymentDate = paymentDate;
    }

    public Guid InvoiceId { get; private set; } 

    public decimal Amount { get; private set; } 

    public PaymentMethod PaymentMethod { get; private set; }

    public DateTime PaymentDate { get; private set; }

    public Invoice Invoice { get; set; } = null!;

}
