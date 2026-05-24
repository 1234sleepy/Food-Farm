using FluentValidation;
using FoodFarm.Product.MicroService.API.Grpc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.MicroService.Domain.Pipelines;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;

namespace Order.MicroService.Domain.DpendencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>))
            .RegisterServicesFromAssembly(typeof(OrderModel).Assembly));

        services
        .AddValidatorsFromAssemblyContaining<AddOrderCommandValidator>(includeInternalTypes: true);

        services.AddGrpcClient<ProductEngine.ProductEngineClient>(opt =>
        {
            opt.Address = new Uri(configuration.GetConnectionString("ProductService")!);
        }).ConfigureChannel(conf =>
        {
            conf.HttpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
        });

        return services;
    }
}
