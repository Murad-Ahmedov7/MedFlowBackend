
using Azure.Core;
using DataAccess.Internals;
using Domain.Entities.Medicines;
using Domain.Entities.Prescriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DataAccess.Repositories;
public sealed class SqlPrescriptionRepository : BaseSqlRepository<Prescription>
{
    public SqlPrescriptionRepository(MedDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<Prescription?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Prescriptions
            .AsNoTracking()
            .Include(p => p.PrescriptionItems)
            .ThenInclude(pi => pi.Medicine)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);


    }

    public async Task<List<Prescription>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Prescriptions
            .AsNoTracking()
            .Include(p => p.PrescriptionItems)
            .ThenInclude(pi => pi.Medicine)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<PrescriptionItem>> GetItemsByPrescriptionIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.PrescriptionItems
            .AsNoTracking()
            .Where(x => x.PrescriptionId == id)
            .Include(x => x.Medicine)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsPrescriptionItemDuplicateAsync(PrescriptionItem prescriptionItem, CancellationToken cancellationToken = default)
    {
        return await DbContext.PrescriptionItems.AnyAsync(x =>
        x.PrescriptionId == prescriptionItem.PrescriptionId &&
        x.MedicineId == prescriptionItem.MedicineId &&
        x.Dose == prescriptionItem.Dose &&
        x.Frequency == prescriptionItem.Frequency &&
        x.DurationInDays == prescriptionItem.DurationInDays &&
        (x.UsageInstruction ?? "").Trim().ToLower() == (prescriptionItem.UsageInstruction ?? "").Trim().ToLower());

    }

    public async Task<bool> PrescriptionExistsForExaminationAsync(Guid examinationId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Prescriptions
            .AnyAsync(x => x.ExaminationId == examinationId, cancellationToken);
    }

}
