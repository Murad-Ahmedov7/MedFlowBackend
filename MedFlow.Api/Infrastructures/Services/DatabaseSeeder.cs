

using DataAccess.Internals;
using Domain.Entities.Auth;
using Domain.Entities.Auth.Enums;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;

namespace MedFlow.Api.Infrastructures.Services;

public class DatabaseSeeder
{
    private readonly MedDbContext _dbContext;

    public DatabaseSeeder(MedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedAsync()
    {
        var adminExists = await _dbContext.Users.AnyAsync(u => u.UserRole == UserRoles.Admin && !u.IsDeleted);

        if (adminExists)
            return;

        var user = new User
        {
            FullName = "Admin1",
            Email = "Admin1@gmail.com",
            Phone = "055-342-34-12",
            PasswordHash = Argon2.Hash("murad1234"),
            UserRole = UserRoles.Admin,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = null,
            IsDeleted = false
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

    }
}