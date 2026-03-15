

using DataAccess.Internals;
using Domain.Entities.Examinations;

namespace DataAccess.Repositories;

public sealed class SqlExaminationRepository : BaseSqlRepository<Examination>
{
    public SqlExaminationRepository(MedDbContext dbContext) : base(dbContext)
    {

    }
}

