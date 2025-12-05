using Cart.MicroService.Domain.Pipelines;
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.CreateCart;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.MicroService.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>))
            .RegisterServicesFromAssembly(typeof(CartModel).Assembly));

        services
        .AddValidatorsFromAssemblyContaining<UpdateCartCommandValidator>(includeInternalTypes: true);

        return services;
    }
}
