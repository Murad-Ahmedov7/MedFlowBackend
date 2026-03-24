
using DataAccess.Internals;
using Domain.Entities.DepartmentServices;
using Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class SqlDepartmentServiceRepository : BaseSqlRepository<DepartmentService>
{
    public SqlDepartmentServiceRepository(MedDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsByDepartmentAndServiceAsync(Guid departmentId, Guid serviceId, CancellationToken cancellationToken = default)
    {
        return await DbContext.DepartmentServices
            .AnyAsync(x => x.DepartmentId == departmentId && x.ServiceId == serviceId, cancellationToken);
    }

    public async Task<List<DepartmentService>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default)
    {
        return await DbContext.DepartmentServices
            .Where(x => x.DepartmentId == departmentId)
            .AsNoTracking()
            .Include(x => x.Service)
            .ToListAsync();
    }
}

