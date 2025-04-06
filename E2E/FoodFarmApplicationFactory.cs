using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Storage;
using Testcontainers.PostgreSql;

namespace E2E;

public class FoodFarmApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder().Build();
    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        var dbContext = new DataContext(
            new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(_dbContainer.GetConnectionString(), opt => opt.MigrationsAssembly(typeof(DataContext).Assembly.FullName))
                .Options);
        await dbContext.Database.MigrateAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:Postgres"] = _dbContainer.GetConnectionString(),
                ["Host"] = "localhost"
            })
            .Build();
        builder.UseConfiguration(configuration);
    }

    public async new Task DisposeAsync()
    {
        await _dbContainer.DisposeAsync();
    }
}
