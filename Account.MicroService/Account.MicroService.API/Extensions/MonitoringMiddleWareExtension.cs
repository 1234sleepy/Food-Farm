using Account.MicroService.API.MiddleWare;

namespace Account.MicroService.API.Extensions;

public static class MonitoringMiddleWareExtension
{
    public static void UseMonitoringMiddleWare(this WebApplication app)
    {
        app.UseMiddleware<MonitoringMiddleWare>();
    }
}