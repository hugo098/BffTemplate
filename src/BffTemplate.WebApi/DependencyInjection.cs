using BffTemplate.Application.Exceptions.Handler;

namespace BffTemplate.WebApi;
public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddExceptionHandler<CustomExceptionHandler>()
            .AddControllers();

        return services;
    }
}
