
using DataAccess.Internals;
using Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class SqlServiceRepository : BaseSqlRepository<Service>
{
    public SqlServiceRepository(MedDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return
            await DbContext.Services
            .AnyAsync(s => s.Name == name, cancellationToken);
    }

}
