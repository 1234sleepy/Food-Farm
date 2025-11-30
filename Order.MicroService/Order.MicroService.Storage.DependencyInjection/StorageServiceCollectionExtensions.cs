using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.DeleteOrder;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;
using Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetAllOrders;
using Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrder;
using Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;
using Order.MicroService.Domain.UseCases.OrderStatusOperation.Quries.GetAllOrderStatuses;
using Order.MicroService.Storage.Mapper;
using Order.MicroService.Storage.Storages.OrderItemOperation;
using Order.MicroService.Storage.Storages.OrderOperation;
using Order.MicroService.Storage.Storages.OrderStatusOperatioin;
using System.Reflection;


namespace Order.MicroService.Storage.DependencyInjection;

public static class StorageServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<DataContext>(options =>
            options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

        services.AddAutoMapper(Assembly.GetAssembly(typeof(DataContext)));

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

        services.AddScoped<IGetAllOrderStatusesStorage, GetAllOrderStatusesStorage>();

        return services;
    }
}
