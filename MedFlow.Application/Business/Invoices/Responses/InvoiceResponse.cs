
using Application.Business.Patients.Responses;

namespace Application.Business.Invoices.Responses;

public class InvoiceResponse
{
    public Guid Id { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal RemainingAmount { get; set; }

    public byte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public PatientInfoResponse Patient { get; set; } = new();

    public List<InvoiceItemResponse> InvoiceItems { get; set; } = new();
}
