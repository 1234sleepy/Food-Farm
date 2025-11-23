using Account.MicroService.Domain.Models;
using Account.MicroService.Domain.Services.JwtTokenService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Account.MicroService.DomainDependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {

        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>))
            .RegisterServicesFromAssembly(typeof(UserModel).Assembly));

        services
            .AddValidatorsFromAssemblyContaining<AddProductCommandValidator>(includeInternalTypes: true);

        services.AddScoped<ITokenService, TokenService>();
        services.AddSingleton<DomainMetrics>();


        return services;
    }
}