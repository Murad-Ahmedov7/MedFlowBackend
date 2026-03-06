using DataAccess.Internals;
using Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories;

public sealed class SqlPatientRepository : BaseSqlRepository<Patient>
{
    public SqlPatientRepository(MedDbContext dbContext) : base(dbContext)
    {


    }

    public async Task<Patient?> GetPatientByFinAsync(string fin, CancellationToken cancellationToken = default)
    {

        // Yalnız oxuma üçün istifadə olunur, dəyişiklik olmayacağına görə tracking söndürülüb.
        // FIN unikaldır, ona görə SingleOrDefault 0 və ya 1 nəticəni təmin edir.

        // Read-only query; AsNoTracking is used to avoid change tracking overhead.
        // FIN is unique, so SingleOrDefault enforces returning 0 or 1 entity.
        return
            await DbContext.Patients
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Fin == fin, cancellationToken);
    }

    public async Task<IReadOnlyList<Patient>> GetPatientsByPhoneAsync(string phone, CancellationToken cancellationToken = default)
    {

        // Phone unikal olmadığı üçün bütün uyğun pasiyentlər list şəklində qaytarılır.
        //IReadOnlyList isə nəticənin yalnız oxuna bilən olduğunu ifadə edir.

        // Phone is not unique, so all matching patients are returned as a list.
        //     IReadOnlyList indicates that the result is read-only.

        return
            await DbContext.Patients
            .AsNoTracking()
            .Where(p => p.Phone == phone)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Patient>> GetPatientsByNameAsync(string? firstname, string? lastname, CancellationToken cancellationToken)
    {
        var query = DbContext.Patients.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(firstname))
        {
            query = query.Where(p => p.FirstName.Contains(firstname));
        }

        if (!string.IsNullOrWhiteSpace(lastname))
        {
            query = query.Where(p => p.LastName.Contains(lastname));
        }

        return await query.ToListAsync(cancellationToken);

    }

    public void Delete(Patient patient)
    {
        patient.IsDeleted = true;
        DbContext.Patients.Update(patient);
    }

}
