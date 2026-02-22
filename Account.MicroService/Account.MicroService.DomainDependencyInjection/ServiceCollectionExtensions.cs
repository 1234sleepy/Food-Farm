using Account.MicroService.Domain.Models;
using Account.MicroService.Domain.Pipelines;

using Account.MicroService.Domain.UseCases.AccountOperation.CreateAccount;
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
            .AddValidatorsFromAssemblyContaining<CreateAccountCommandValidator>(includeInternalTypes: true);



        return services;
    }
}