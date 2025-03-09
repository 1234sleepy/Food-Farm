using Domain.UseCases.AdminOrderOperation.Command.DeleteOrder;
using Domain.UseCases.AdminOrderOperation.Command.UpdateOrder;
using Domain.UseCases.AdminOrderOperation.Queries.GetAllOrder;
using Domain.UseCases.AdminOrderOperation.Queries.GetOrder;
using Domain.UseCases.AdminProductOperation.Command.AddProduct;
using Domain.UseCases.AdminProductOperation.Command.DeleteProduct;
using Domain.UseCases.AdminProductOperation.Command.UpdateProduct;
using Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;
using Domain.UseCases.AdminProductOperation.Queries.GetProduct;
using Domain.UseCases.OrderItemOperation.Command.AddOrderItem;
using Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;
using Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;
using Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;
using Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;
using Domain.UseCases.OrderOperation.Command.AddOrder;
using Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage.Entities;
using Storage.Storages.AdminOrderOperation;
using Storage.Storages.AdminProductOperation;
using Storage.Storages.OrderItemsOperation;
using Storage.Storages.OrderOperation;
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
        services.AddScoped<IDeleteProductStorage, DeleteProductStorage>();

        services.AddScoped<IGetAllOrdersStorage, GetAllOrdersStorage>();
        services.AddScoped<IUpdateOrderStorage, UpdateOrderStorage>();
        services.AddScoped<IGetOrderStorage, GetOrderStorage>();
        services.AddScoped<IDeleteOrderStorage, DeleteOrderStorage>();

        services.AddScoped<IAddOrderItemStorage, AddOrderItemStorage>();
        services.AddScoped<IGetAllOrderItemsStorage, GetAllOrderItemsStorage>();
        services.AddScoped<IUpdateOrderItemStorage, UpdateOrderItemStorage>();
        services.AddScoped<IGetOrderItemStorage, GetOrderItemStorage>();
        services.AddScoped<IDeleteOrderItemStorage, DeleteOrderItemStorage>();

        services.AddScoped<IAddOrderStorage, AddOrderStorage>();
        services.AddScoped<IGetOrderByPhoneStorage, GetOrderByPhoneStorage>();



        services.AddAutoMapper(con => con.AddMaps(Assembly.GetAssembly(typeof(DataContext))));




        return services;
    }
}
