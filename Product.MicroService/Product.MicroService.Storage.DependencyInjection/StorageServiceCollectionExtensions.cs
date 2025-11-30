using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.MicroService.Domain.UseCases.ImageOperation.Command.AddImage;
using Product.MicroService.Domain.UseCases.ImageOperation.Command.DeleteImage;
using Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage;
using Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetImage;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.RemoveLabelFromProduct;
using Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllLables;
using Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllUsedLabelByProductId;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.DeleteProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateCharacterisitc;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct;
using Product.MicroService.Storage.Mapper;
using Product.MicroService.Storage.Storages.ImageOperation;
using Product.MicroService.Storage.Storages.LabelOperation;
using Product.MicroService.Storage.Storages.ProductOperation;
using System.Reflection;

namespace Product.MicroService.Storage.DependencyInjection;

public static class StorageServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<DataContext>(options =>
            options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

        services.AddAutoMapper((provider, cfg) =>
        {
            cfg.AddProfile(new ImageProfile(provider.GetRequiredService<IConfiguration>()));
        }, Assembly.GetAssembly(typeof(DataContext)));

        services.AddScoped<IAddProductStorage, AddProductStorage>();
        services.AddScoped<IGetAllProductsStorage, GetAllProductsStorage>();
        services.AddScoped<IUpdateProductStorage, UpdateProductStorage>();
        services.AddScoped<IGetProductStorage, GetProductStorage>();
        services.AddScoped<IDeleteProductStorage, DeleteProductStorage>();

        services.AddScoped<IUpdateCharacteristicStorage, UpdateCharacteristicStorage>();

        services.AddScoped<IAddImageStorage, AddImageStorage>();
        services.AddScoped<IDeleteImageStorage, DeleteImageStorage>();
        services.AddScoped<IGetImageStorage, GetImageStorage>();
        services.AddScoped<ISetIsMainImageStorage, SetIsMainImageStorage>();

        services.AddScoped<IAddLabelStorage, AddLabelStorage>();
        services.AddScoped<IGetAllLabelsStorage, GetAllLabelStorage>();
        services.AddScoped<IAddLabelToProductStorage, AddLabelToProductStorage>();
        services.AddScoped<IGetAllUsedLabelByProductIdStorage, GetAllUsedLabelByProductIdStorage>();
        services.AddScoped<IRemoveLabelFromProductStorage, RemoveLabelFromProductStorage>();

        return services;
    }
}
