using Microsoft.Extensions.DependencyInjection;


namespace Order.MicroService.Storage.DependencyInjection;

public static class StorageServiceCollectionExtensions
{
    public static IServiceCollection AddStorage(this IServiceCollection services, string connectionString)
    {
        //services.AddDbContextPool<DataContext>(options =>
        //    options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));


        //services.AddAutoMapper((provider, cfg) =>
        //{
        //    cfg.AddProfile(new ImageProfile(provider.GetRequiredService<IConfiguration>()));
        //}, Assembly.GetAssembly(typeof(DataContext)));





        return services;
    }
}
