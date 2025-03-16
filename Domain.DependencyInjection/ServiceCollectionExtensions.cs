using Domain.Pipelines;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Command.AddProduct;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {

        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>))
            .RegisterServicesFromAssembly(typeof(ProductModel).Assembly));

        services
            .AddValidatorsFromAssemblyContaining<AddProductCommandValidator>(includeInternalTypes: true);
        return services;
    }
}