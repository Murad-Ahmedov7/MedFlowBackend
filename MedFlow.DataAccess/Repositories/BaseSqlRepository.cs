using DataAccess.Internals;
using Domain.Entities.Demo;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public abstract class BaseSqlRepository<T> where T : class
{
    private readonly MedDbContext _dbContext;


    protected BaseSqlRepository(MedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected MedDbContext DbContext => _dbContext;


    public void Add(T entity)
    {
        DbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>()
            .FindAsync(id, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    }

}
//.OrderBy(c=>c.Created at) bunu sonra interface ile yaz