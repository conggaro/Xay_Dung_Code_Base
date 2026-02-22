using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Services;

namespace MyApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISanPhamService, SanPhamService>();

        return services;
    }
}