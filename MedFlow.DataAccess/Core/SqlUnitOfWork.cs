using DataAccess.Internals;
using DataAccess.Repositories;

namespace DataAccess.Core;

public sealed class SqlUnitOfWork
{
    private readonly MedDbContext _dbContext;
    private SqlCategoryRepository? _categoryRepository;

    public SqlUnitOfWork(MedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public SqlCategoryRepository CategoryRepository => _categoryRepository ??= new SqlCategoryRepository(_dbContext);

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
