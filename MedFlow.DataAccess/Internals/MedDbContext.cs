using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Internals;


// Tətbiqin əsas Entity Framework DbContext-i.
// Məlumat bazası ilə əlaqəni və entity konfiqurasiyalarını idarə edir.
// Category entity-si üçün soft delete tətbiq olunur:
// default materialized sorğularda (məs. ToList(), FirstOrDefault())
// IsDeleted = true olan qeydlər avtomatik olaraq gizlədilir.
//
// Main Entity Framework DbContext of the application.
// Manages database access and entity configurations.
// Applies a soft delete mechanism for Category entities:
// records marked as IsDeleted are automatically excluded
// from default materialized queries (e.g. ToList(), FirstOrDefault()).


public sealed class MedDbContext : DbContext
{
    public MedDbContext(DbContextOptions<MedDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<User>().HasQueryFilter(e=> !e.IsDeleted);

    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }
}


