
namespace Application.Business.Invoices.Responses;

public class PatientInvoiceResponse
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal RemainingAmount {  get; set; }

    public byte Status { get; set; }

    public DateTime CreatedAt { get; set; }

}
