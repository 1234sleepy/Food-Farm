using Cart.MicroService.Domain.UseCases.CreateCart;
using Cart.MicroService.Domain.UseCases.ResetCart;
using Cart.MicroService.Storage.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;


namespace Cart.MicroService.Storage.DependencyInjection;

public static class StorageServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<DataContext>(options =>
            options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

        services.AddAutoMapper(conf =>
        {

        },Assembly.GetAssembly(typeof(DataContext)
        ));

        var domainInterfaces = Assembly.GetAssembly(typeof(IUpdateCartStorage))!
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


        //services.AddScoped<IUpdateCartStorage, UpdateCartStorage>();
        //services.AddScoped<IResetCartStorage, ResetCartStorage>();


        return services;
    }
}
