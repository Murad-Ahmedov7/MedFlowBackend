

namespace Application.Business.Invoices.Requests;

public record class InvoiceItemRequest
{
    public Guid DepartmentServiceId { get; set; }

    public int Quantity { get; set; }
}
