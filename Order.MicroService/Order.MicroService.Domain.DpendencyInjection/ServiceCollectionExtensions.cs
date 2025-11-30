using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Order.MicroService.Domain.Pipelines;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;

namespace Order.MicroService.Domain.DpendencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>))
            .RegisterServicesFromAssembly(typeof(OrderModel).Assembly));

        services
        .AddValidatorsFromAssemblyContaining<AddOrderCommandValidator>(includeInternalTypes: true);

        return services;
    }
}
