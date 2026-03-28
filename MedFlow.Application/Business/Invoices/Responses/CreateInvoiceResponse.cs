
namespace Application.Business.Invoices.Responses;


public class CreateInvoiceResponse
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public decimal TotalAmount { get; set; }

    public byte Status { get; set; }

    public DateTime CreatedAt { get; set; }
}
