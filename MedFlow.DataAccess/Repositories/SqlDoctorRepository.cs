

using DataAccess.Internals;
using Domain.Entities.Doctors;

namespace DataAccess.Repositories;

public sealed class SqlDoctorRepository : BaseSqlRepository<Doctor>
{
    public SqlDoctorRepository(MedDbContext dbContext) : base(dbContext)
    {

    }
}

