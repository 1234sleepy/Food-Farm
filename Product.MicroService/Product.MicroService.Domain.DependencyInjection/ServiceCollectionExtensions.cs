using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

namespace Product.MicroService.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(typeof(ProductModel).Assembly));

        services
            .AddValidatorsFromAssemblyContaining<AddProductCommandValidator>(includeInternalTypes: true);

        return services;
    }
}
