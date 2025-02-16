using Domain.Models;
using Domain.UseCases.AdminProductOperation.Command.AddProduct;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependencyInjection;

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