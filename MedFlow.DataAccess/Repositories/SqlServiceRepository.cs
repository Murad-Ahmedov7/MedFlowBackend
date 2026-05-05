
using DataAccess.Internals;
using Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class SqlServiceRepository : BaseSqlRepository<Service>
{
    public SqlServiceRepository(MedDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsByNameAndDepartmentAsync(string name, Guid departmentId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Services
            .AnyAsync(x => x.Name == name && x.DepartmentId == departmentId, cancellationToken);
    }

    public async Task<List<Service>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Services
            .Where(x => x.DepartmentId == departmentId)
            .AsNoTracking()
            .ToListAsync();
    }


}
