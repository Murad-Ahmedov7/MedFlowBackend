using MedFlow.Api.Infrastructures.Services;


namespace MedFlow.Api.Infrastructures.Extensions;

public static class DatabaseSeederExtensions
{
    public static async Task SeedDatabaseAsnyc(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
        await seeder.SeedAsync();
    }
}

