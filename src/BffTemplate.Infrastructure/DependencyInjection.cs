using BffTemplate.Application.Abstractions.Services;
using BffTemplate.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BffTemplate.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<ITodoService, TodoService>("TodoApi", client =>
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        });

        return services;
    }
}
