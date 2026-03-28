

using DataAccess.Internals;
using Domain.Entities.Billing.Invoices;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class SqlInvoiceRepository : BaseSqlRepository<Invoice>
{
    public SqlInvoiceRepository(MedDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<bool> InvoiceItemExistsAsync(Guid invoiceId, Guid departmentServiceId, CancellationToken cancellationToken = default)
    {
        return await DbContext.InvoiceItems
            .AnyAsync(x => x.InvoiceId == invoiceId && x.DepartmentServiceId == departmentServiceId, cancellationToken = default);
    }

    public async Task<List<Invoice>> GetPatientInvoicesAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Invoices
            .Where(x => x.PatientId == patientId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Invoice?> GetByIdWithDetailsAsync(Guid invoiceId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Invoices
            .Include(x => x.InvoiceItems)
            .Include(x => x.Patient)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == invoiceId, cancellationToken);
    }

    public async Task<List<Invoice>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Invoices
            .Include(x => x.InvoiceItems)
            .Include(x => x.Patient)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

}