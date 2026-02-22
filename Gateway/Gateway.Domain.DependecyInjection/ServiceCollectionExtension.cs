using FluentValidation;
using FoodFarm.Account.MicroService.API.Grpc;
using Gateway.Domain.Models;
using Gateway.Domain.Pipelines;
using Gateway.Domain.Services.JwtTokenService;
using Gateway.Domain.UseCases.AuthOperation.CreateAccount;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Domain.DependecyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg
            .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>))
            .RegisterServicesFromAssembly(typeof(UserModel).Assembly));

        services.AddSingleton<ITokenService, TokenService>();

        services.AddGrpcClient<AccountEngine.AccountEngineClient>(opt =>
        {
            opt.Address = new Uri(configuration.GetConnectionString("AccountService")!);
        }).ConfigureChannel(conf =>
        {
            conf.HttpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
        });


        services
            .AddValidatorsFromAssemblyContaining<CreateAccountCommandValidator>(includeInternalTypes: true);

        return services;
    }
}