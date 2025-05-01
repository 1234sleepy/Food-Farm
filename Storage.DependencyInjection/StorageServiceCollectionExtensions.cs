using Domain.UseCases.AccountOperations.Command.CreateAccount;
using Domain.UseCases.AccountOperations.Command.LogIn;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.AddImage;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.DeleteImage;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage;
using Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;
using Domain.UseCases.AdminOperatation.OrderOperation.Command.DeleteOrder;
using Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder;
using Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetAllOrders;
using Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetOrder;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.DeleteProduct;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateProduct;
using Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;
using Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetProduct;
using Domain.UseCases.OrderItemOperation.Command.AddOrderItem;
using Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;
using Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;
using Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;
using Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;
using Domain.UseCases.OrderOperation.Command.AddOrder;
using Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage.Entities;
using Storage.Mapper;
using Storage.Storages.AccountOperation;
using Storage.Storages.Admin.ImageOperation;
using Storage.Storages.Admin.OrderOperation;
using Storage.Storages.Admin.ProductOperation;
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
            //.AddUserManager<UserManager<User>>()
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


        services.AddScoped<IAddImageStorage, AddImageStorage>();
        services.AddScoped<IDeleteImageStorage, DeleteImageStorage>();
        services.AddScoped<IGetImageStorage, GetImageStorage>();
        services.AddScoped<ISetIsMainImageStorage, SetIsMainImageStorage>();

        services.AddScoped<ICreateAccountStorage, CreateAcountStorage>();
        services.AddScoped<ILogInStorage, LogInStorage>();


        services.AddAutoMapper((provider, cfg) =>
        {
            cfg.AddProfile(new ImageProfile(provider.GetRequiredService<IConfiguration>()));
        }, Assembly.GetAssembly(typeof(DataContext)));





        return services;
    }
}
