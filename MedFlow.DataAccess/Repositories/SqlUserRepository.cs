using DataAccess.Internals;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
    public sealed class SqlUserRepository : BaseSqlRepository
    {
        public SqlUserRepository(MedDbContext dbContext) : base(dbContext)
        {

        }

        public void Add(User user)
        {
            DbContext.Add(user);
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public void Update(User user)
        {
            DbContext.Users.Update(user);
        }

        public void Delete(User user)
        {
            user.IsDeleted= true;
            DbContext.Users.Update(user);
        }
    }
}
