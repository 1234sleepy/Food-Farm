using Cart.MicroService.API.MiddleWare;

namespace Cart.MicroService.API.Extensions;

public static class MonitoringMiddleWareExtension
{
    public static void UseMonitoringMiddleWare(this WebApplication app)
    {
        app.UseMiddleware<MonitoringMiddleWare>();
    }
}
