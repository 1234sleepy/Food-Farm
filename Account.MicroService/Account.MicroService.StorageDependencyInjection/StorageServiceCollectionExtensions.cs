using Account.MicroService.Domain.UseCases.AccountOperation.Check;
using Account.MicroService.Domain.UseCases.AccountOperation.CreateAccount;
using Account.MicroService.Domain.UseCases.AccountOperation.LogIn;
using Account.MicroService.Storage;
using Account.MicroService.Storage.Entities;
using Account.MicroService.Storage.Storages.AccountOperation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Account.MicroService.StorageDependencyInjection;

public static class StorageServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, string connectionString)
    {

        services.AddIdentityCore<User>(options => options.Password.RequireNonAlphanumeric = false)
            .AddRoles<Role>()
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<DataContext>();

        services.AddDbContextPool<DataContext>(options =>
            options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));


        services.AddScoped<ICreateAccountStorage, CreateAcountStorage>();
        services.AddScoped<ILogInStorage, LogInStorage>();
        services.AddScoped<ICheckStorage, CheckStorage>();

        return services;
    }
}