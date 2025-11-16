using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Order.MicroService.Domain.DpendencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        //services.AddMediatR(cfg => cfg
        //.RegisterServicesFromAssembly(typeof().Assembly));

        //services
        //.AddValidatorsFromAssemblyContaining<>(includeInternalTypes: true);

        return services;
    }
}
