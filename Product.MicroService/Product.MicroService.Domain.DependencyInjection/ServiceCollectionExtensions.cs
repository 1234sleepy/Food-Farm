using Microsoft.Extensions.DependencyInjection;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
           .RegisterServicesFromAssembly(typeof(ProductModel).Assembly));

        return services;
    }
}
