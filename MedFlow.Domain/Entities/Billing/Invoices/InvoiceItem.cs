

using Domain.Entities.Base;

namespace Domain.Entities.Billing.Invoices;

public class InvoiceItem : BaseEntity
{

    private InvoiceItem()
    {

    }
    public InvoiceItem(Guid invoiceId, Guid departmentServiceId, string serviceName, decimal price, int quantity)
    {
        InvoiceId = invoiceId;
        DepartmentServiceId = departmentServiceId;
        ServiceName = serviceName;
        Price = price;
        Quantity = quantity;
        Total = price * quantity;

    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
        Total = Price * Quantity;
    }

    public Guid InvoiceId { get; private set; }

    public Guid DepartmentServiceId { get; private set; }

    public string ServiceName { get; private set; } = null!;

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public decimal Total { get; private set; }

    public Invoice Invoice { get; private set; } = null!;
}


