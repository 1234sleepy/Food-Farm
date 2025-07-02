using OpenTelemetry.Metrics;

namespace API.Monitoring;

public static class OpenTelemetryServiceCollectionExtension 
{
    public static IServiceCollection AddApiMetrics(this IServiceCollection services, IConfiguration conf, IWebHostEnvironment environment)
    {
        services.AddOpenTelemetry()
            .WithMetrics(static builder => builder
                .AddAspNetCoreInstrumentation()
                .AddMeter("FoodFarm")
                .AddPrometheusExporter(opt => opt.ScrapeEndpointPath = "/metrics"));
        return services;
    }
}
