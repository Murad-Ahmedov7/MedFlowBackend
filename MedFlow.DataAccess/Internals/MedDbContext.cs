using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Internals;

public sealed class MedDbContext : DbContext
{
    public MedDbContext(DbContextOptions<MedDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasQueryFilter(e => !e.IsDeleted);
    }

    public DbSet<Category> Categories { get; set; }
}
