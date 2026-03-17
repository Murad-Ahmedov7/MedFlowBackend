

using DataAccess.Internals;
using Domain.Entities.Medicines;

namespace DataAccess.Repositories;

public class SqlMedicineRepository : BaseSqlRepository<Medicine>
{
    public SqlMedicineRepository(MedDbContext dbContext) : base(dbContext)
    {
    }

}

