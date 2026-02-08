using DataAccess.Core;
using DataAccess.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DependencyInjections
{
    public static IServiceCollection AddSqlServerServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MedDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<SqlUnitOfWork>();
        return services;
    }
}
