using DataAccess.Internals;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
    public sealed class SqlUserRepository : BaseSqlRepository<User>
    {
        public SqlUserRepository(MedDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public void Delete(User user)
        {
            user.IsDeleted= true;
            DbContext.Users.Update(user);
        }
    }
}
