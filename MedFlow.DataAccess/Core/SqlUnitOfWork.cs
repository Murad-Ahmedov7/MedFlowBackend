using DataAccess.Internals;
using DataAccess.Repositories;

namespace DataAccess.Core;


// SqlUnitOfWork DataAccess layer-də Unit of Work pattern-in
// SQL / EF Core əsaslı implementasiyasıdır.
// Repository-lərin eyni DbContext üzərindən işləməsini təmin edir
// və bütün dəyişikliklərin tək SaveChanges çağırışı ilə
// atomic şəkildə commit olunmasına imkan yaradır.
//
// SqlUnitOfWork is the SQL / EF Core implementation of the
// Unit of Work pattern in the DataAccess layer.
// It ensures that repositories share the same DbContext
// and that all changes are committed atomically
// through a single SaveChanges call.

public sealed class SqlUnitOfWork
{
    private readonly MedDbContext _dbContext;

    private SqlCategoryRepository? _categoryRepository;

    private SqlUserRepository? _userRepository;

    private SqlAuthRepository? _authRepository;

    private SqlPatientRepository? _patientRepository;

    private SqlDepartmentRepository? _departmentRepository;

    public SqlUnitOfWork(MedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Category repository-ni lazy şəkildə yaradır
    // və eyni DbContext instance-i ilə işləməsini təmin edir.
    //
    // Lazily initializes the Category repository
    // and ensures it operates on the same DbContext instance.

    public SqlCategoryRepository CategoryRepository => _categoryRepository ??= new SqlCategoryRepository(_dbContext);

    public SqlUserRepository UserRepository=> _userRepository ??= new SqlUserRepository(_dbContext);

    public SqlAuthRepository AuthRepository=> _authRepository ??= new SqlAuthRepository(_dbContext);

    public SqlPatientRepository PatientRepository => _patientRepository ??=new SqlPatientRepository(_dbContext);

    public SqlDepartmentRepository DepartmentRepository => _departmentRepository ??= new SqlDepartmentRepository(_dbContext);


    // DbContext üzərində edilmiş bütün dəyişiklikləri
    // tək nöqtədən commit edir.
    //
    // Commits all pending changes on the DbContext
    // through a single centralized call.
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
