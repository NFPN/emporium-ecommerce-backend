using Emporium.Application.Service;
using Emporium.Core;
using Emporium.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Emporium.Common;

public static class EmporiumExtensions
{
    public static IServiceCollection AddEmporiumServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddScoped<ProductService>();
        return services;
    }
}
