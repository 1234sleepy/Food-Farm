using Domain.Pipelines;
using Domain.Services.JwtTokenService;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;
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

        services.AddScoped<ITokenService, TokenService>();

        
        return services;
    }
}