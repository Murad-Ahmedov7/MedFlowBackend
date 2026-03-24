using Domain.Entities.Appointments;
using Domain.Entities.Auth;
using Domain.Entities.Demo;
using Domain.Entities.Departments;
using Domain.Entities.DepartmentServices;
using Domain.Entities.Doctors;
using Domain.Entities.DoctorSchedules;
using Domain.Entities.Examinations;
using Domain.Entities.Medicines;
using Domain.Entities.Patients;
using Domain.Entities.Prescriptions;
using Domain.Entities.Services;
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

        modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Patient>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Department>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Doctor>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<DoctorSchedule>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Examination>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Medicine>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Prescription>().HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Service>().HasQueryFilter(e => !e.IsDeleted);
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<Examination> Examinations { get; set; }

    public DbSet<Medicine> Medicines { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }

    public DbSet<Service> Services { get; set; }

    public DbSet<DepartmentService> DepartmentServices { get; set; }
}


