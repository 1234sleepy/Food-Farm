using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Product.MicroService.Domain.Mapper;
using Product.MicroService.Domain.Pipelines;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;
using System.Reflection;

namespace Product.MicroService.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddAutoMapper((provider, cfg) =>
        {

        }, Assembly.GetAssembly(typeof(ProductEntityProfile)));

        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>))
            .RegisterServicesFromAssembly(typeof(ProductModel).Assembly));

        services
            .AddValidatorsFromAssemblyContaining<AddProductCommandValidator>(includeInternalTypes: true);

        return services;
    }
}
