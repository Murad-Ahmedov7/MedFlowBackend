using MedFlow.Api.Infrastructures.Middlewares;

namespace MedFlow.Api.Infrastructures.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
