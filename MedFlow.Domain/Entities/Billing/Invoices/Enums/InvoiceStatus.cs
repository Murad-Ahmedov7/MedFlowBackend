

namespace Domain.Entities.Billing.Invoices.Enums;
public enum InvoiceStatus:byte
{
    Unpaid = 0,
    PartiallyPaid = 1,
    Paid = 2
}
