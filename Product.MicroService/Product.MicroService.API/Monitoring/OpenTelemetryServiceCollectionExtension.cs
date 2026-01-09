using Npgsql;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Reflection;

namespace Product.MicroService.API.Monitoring;

public static class OpenTelemetryServiceCollectionExtension
{
    public static IServiceCollection AddApiMetrics(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenTelemetry()
            .WithMetrics(builder => builder
                .AddAspNetCoreInstrumentation()
                .AddMeter(Assembly.GetExecutingAssembly().GetName().Name!)
                .AddPrometheusExporter(opt => { opt.ScrapeEndpointPath = "/metriccs"; })
            )
            .ConfigureResource(res => res.AddService(Assembly.GetExecutingAssembly().GetName().Name!))
            .WithTracing(conf => conf
                .AddAspNetCoreInstrumentation()
                .AddEntityFrameworkCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddSource(Assembly.GetExecutingAssembly().GetName().Name!)
                .AddOtlpExporter(options => options.Endpoint = new Uri(configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]!))
            );


        return services;
    }
}
