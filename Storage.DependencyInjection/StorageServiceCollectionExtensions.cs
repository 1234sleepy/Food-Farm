using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Storage.DependencyInjection
{
    public static class StorageServiceCollectionExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));
            return services;
        }
    }
}
