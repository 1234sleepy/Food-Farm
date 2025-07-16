using OpenTelemetry.Metrics;

namespace API.Monitoring;

public static class OpenTelemetryServiceCollectionExtension 
{
    public static IServiceCollection AddApiMetrics(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenTelemetry()
            .WithMetrics(builder => builder
                .AddAspNetCoreInstrumentation()
                .AddMeter(configuration["Monitoring:MeterName"]!)
                .AddPrometheusExporter(opt => opt.ScrapeEndpointPath = "/metrics")
                .AddView("http.server.request.duration",new ExplicitBucketHistogramConfiguration
                    {
                        Boundaries = [0, 0.05, 0.1, 0.25, 0.5, 0.75 , 1, 2.5, 5, 10 ]
                    })
                );
        return services;
    }
}
