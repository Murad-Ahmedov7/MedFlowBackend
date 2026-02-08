using DataAccess.Internals;

namespace DataAccess.Repositories;

public abstract class BaseSqlRepository
{
    private readonly MedDbContext _dbContext;

    protected BaseSqlRepository(MedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected MedDbContext DbContext => _dbContext;
}
