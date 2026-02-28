


using DataAccess.Internals;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;




public sealed class SqlAuthRepository : BaseSqlRepository
{
    public SqlAuthRepository(MedDbContext dbContext) : base(dbContext)
    {

    }

    public void Add(RefreshToken refreshToken)
    {
        DbContext.RefreshTokens.Add(refreshToken);
    }

    public void Update(RefreshToken refreshToken)
    {
        DbContext.RefreshTokens.Update(refreshToken);
    }

    public void Delete(RefreshToken refreshToken)
    {
        DbContext.RefreshTokens.Remove(refreshToken);
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        return await DbContext.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rf=>rf.Token == token, cancellationToken);
    }
}

