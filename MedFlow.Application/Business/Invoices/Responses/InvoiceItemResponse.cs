
namespace Application.Business.Invoices.Responses;

public class InvoiceItemResponse
{
    public Guid Id { get; set; }
    public Guid DepartmentServiceId {  get; set; }

    public string ServiceName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }

    public DateTime CreatedAt { get; set; }
}
