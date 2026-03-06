

using DataAccess.Internals;
using Domain.Entities.Departments;

namespace DataAccess.Repositories;

public sealed class SqlDepartmentRepository : BaseSqlRepository<Department>
{
    public SqlDepartmentRepository(MedDbContext dbContext) : base(dbContext)
    {

    }
}


