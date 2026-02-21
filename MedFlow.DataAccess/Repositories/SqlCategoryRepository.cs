using DataAccess.Internals;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class SqlCategoryRepository : BaseSqlRepository
{
    public SqlCategoryRepository(MedDbContext dbContext) : base(dbContext)
    {
    }

    public void Add(Category category)
    {
        DbContext.Add(category);
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Categories
            .OrderBy(c => c.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public void Update(Category category)
    {
        DbContext.Categories.Update(category);
    }

    // Soft silmə: obyekt DB-dən silinmir, yalnız silinmiş kimi işarələnir

    // Soft delete: entity is not removed from DB, only marked as deleted

    public void Delete(Category category)
    {
        category.IsDeleted = true;
        DbContext.Categories.Update(category);
    }
}
