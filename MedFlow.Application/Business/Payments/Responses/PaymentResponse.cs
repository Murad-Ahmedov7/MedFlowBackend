
using Domain.Entities.Billing.Payments.Enums;

namespace Application.Business.Payments.Responses;

public class PaymentResponse
{
    public Guid Id { get; set; }

    public Guid InvoiceId { get; set; }

    public decimal Amount { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public DateTime PaymentDate { get; set; }

    public DateTime CreatedAt { get; set; }
}

