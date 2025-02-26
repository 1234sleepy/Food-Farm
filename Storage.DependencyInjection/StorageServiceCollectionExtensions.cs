using Domain.UseCases.AdminProductOperation.Command.AddProduct;
using Domain.UseCases.AdminProductOperation.Command.UpdateProduct;
using Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;
using Domain.UseCases.AdminProductOperation.Queries.GetProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage.Entities;
using Storage.Storages.AdminProductOperation;
using System.Reflection;

namespace Storage.DependencyInjection;

public static class StorageServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, string connectionString)
    {

        services.AddIdentityCore<User>(options => options.Password.RequireNonAlphanumeric = false)
            .AddRoles<Role>()
            .AddEntityFrameworkStores<DataContext>();

        services.AddDbContextPool<DataContext>(options =>
            options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

        services.AddScoped<IAddProductStorage, AddProductStorage>();
        services.AddScoped<IGetAllProductsStorage, GetAllProductsStorage>();
        services.AddScoped<IUpdateProductStorage, UpdateProductStorage>();
        services.AddScoped<IGetProductStorage, GetProductStorage>();
        services.AddAutoMapper(con => con.AddMaps(Assembly.GetAssembly(typeof(DataContext))));




        return services;
    }
}
