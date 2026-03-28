
using Domain.Entities.Base;
using Domain.Entities.Billing.Invoices.Enums;
using Domain.Entities.Billing.Payments;
using Domain.Entities.Patients;
using Domain.Exceptions;

namespace Domain.Entities.Billing.Invoices;


public class Invoice : BaseEntity
{
    private Invoice()
    {

    }
    public Invoice(Guid patientId)
    {
        PatientId = patientId;
        TotalAmount = 0;
        PaidAmount = 0;
        Status = InvoiceStatus.Unpaid;

    }
    public void AddItem(InvoiceItem item)
    {

        InvoiceItems = new List<InvoiceItem>();
        InvoiceItems.Add(item);

        TotalAmount += item.Total;
    }

    public void AddPayment(decimal amount)
    {

        var remaining = TotalAmount - PaidAmount;


        if (remaining <= 0)
            throw new ConflictException("Invoice is already fully paid.");


        if (amount > remaining) throw new ClientException($"Payment exceeds remaining balance. Remaining amount: {remaining}.");

        PaidAmount += amount;

        if (PaidAmount == TotalAmount) Status = InvoiceStatus.Paid;
        else  Status = InvoiceStatus.PartiallyPaid;
    }


    public Guid PatientId { get; private set; }

    public decimal TotalAmount { get; private set; }

    public decimal PaidAmount { get; private set; }

    public InvoiceStatus Status { get; private set; }

    public Patient Patient { get; private set; } = null!;

    public ICollection<InvoiceItem> InvoiceItems { get; private set; } = null!;

    public ICollection<Payment> Payments { get; private set; } = null!;

}
