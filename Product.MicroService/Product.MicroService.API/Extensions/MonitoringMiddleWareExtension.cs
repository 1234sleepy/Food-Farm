using Product.MicroService.API.MidddleWare;

namespace Product.MicroService.API.Extensions;

public static class MonitoringMiddleWareExtension
{
    public static void UseMonitoringMiddleWare(this WebApplication app)
    {
        app.UseMiddleware<MonitoringMiddleWare>();
    }
}
