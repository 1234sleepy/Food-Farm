using Order.MicroService.API.MiddleWare;

namespace Order.MicroService.API.Extensions;

public static class MonitoringMiddleWareExtension
{
    public static void UseMonitoringMiddleWare(this WebApplication app)
    {
        app.UseMiddleware<MonitoringMiddleWare>();
    }
}
