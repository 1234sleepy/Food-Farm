using Account.MicroService.Domain.UseCases.AccountOperation.Check;
using Account.MicroService.Domain.UseCases.AccountOperation.CreateAccount;
using Account.MicroService.Domain.UseCases.AccountOperation.LogIn;
using Account.MicroService.Storage;
using Account.MicroService.Storage.Entities;
using Account.MicroService.Storage.Storages.AccountOperation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

        var domainInterfaces = Assembly.GetAssembly(typeof(ICreateAccountStorage))!
    .GetTypes()
    .Where(x => x.IsInterface);

        var storageClasses = Assembly.GetAssembly(typeof(DataContext))!
            .GetTypes()
            .Where(x => x is { IsClass: true, IsAbstract: false });

        foreach (var @interface in domainInterfaces)
        {
            foreach (var @class in storageClasses)
            {
                if (!@interface.IsAssignableFrom(@class)) continue;

                services.AddScoped(@interface, @class);
            }
        }

        //services.AddScoped<ICreateAccountStorage, CreateAcountStorage>();
        //services.AddScoped<ILogInStorage, LogInStorage>();
        //services.AddScoped<ICheckStorage, CheckStorage>();

        return services;
    }
}