using Application.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AssemblyKernel).Assembly);
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(AssemblyKernel).Assembly); });
        services.AddValidatorsFromAssembly(typeof(AssemblyKernel).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
