using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Storage;
using Testcontainers.PostgreSql;

namespace E2E;

public class FoodFarmApplicationFactory : WebApplicationFactory<API.Program>, IAsyncLifetime
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
    //protected override IHost CreateHost(IHostBuilder builder)
    //{
    //    builder.ConfigureWebHost(conf =>
    //    {
    //        conf.ConfigureServices(s => s.AddSingleton<IServer, KestrelTestServer>());
    //    });
    //    return base.CreateHost(builder);
    //}

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {

        var assembly = typeof(API.Program).Assembly;
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:Postgres"] = _dbContainer.GetConnectionString(),
                ["Host"] = "localhost",
                //["Kestrel:Endpoints:https:Url"] = "https://localhost:8501",
            })
            .Build();
        builder.UseConfiguration(configuration);
        //base.ConfigureWebHost(builder);
    }

    public async new Task DisposeAsync()
    {
        await _dbContainer.DisposeAsync();
    }
}
