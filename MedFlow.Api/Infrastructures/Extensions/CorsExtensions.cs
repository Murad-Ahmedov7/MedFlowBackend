

namespace MedFlow.Api.Infrastructures.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsServices(this IServiceCollection services,IConfiguration config)
    {
        var origins = config
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy
                    .WithOrigins(origins!)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}
