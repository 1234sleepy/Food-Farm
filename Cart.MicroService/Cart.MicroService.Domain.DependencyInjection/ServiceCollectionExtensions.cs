using Cart.MicroService.Domain.Pipelines;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.MicroService.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));
         //   .RegisterServicesFromAssembly(typeof().Assembly));

        //services
        //.AddValidatorsFromAssemblyContaining<>(includeInternalTypes: true);

        return services;
    }
}
