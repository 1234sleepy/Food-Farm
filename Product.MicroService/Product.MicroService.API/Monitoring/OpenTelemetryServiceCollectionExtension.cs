namespace Product.MicroService.API.Monitoring;

public static class OpenTelemetryServiceCollectionExtension
{
    public static IServiceCollection AddApiMetrics(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}


//Additional endpoints.