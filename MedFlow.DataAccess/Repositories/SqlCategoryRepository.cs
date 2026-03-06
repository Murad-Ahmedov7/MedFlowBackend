using DataAccess.Internals;
using Domain.Entities.Demo;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class SqlCategoryRepository : BaseSqlRepository<Category>
{
    public SqlCategoryRepository(MedDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Categories
            .OrderBy(c => c.CreatedAt)
            .ToListAsync(cancellationToken);
    }


    // Soft silmə: obyekt DB-dən silinmir, yalnız silinmiş kimi işarələnir

    // Soft delete: entity is not removed from DB, only marked as deleted

    public void Delete(Category category)
    {
        category.IsDeleted = true;
        DbContext.Categories.Update(category);
    }
}
