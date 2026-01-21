using Order.MicroService.API.Middleware;

namespace Order.MicroService.API.Extensions;

public static class ErrorMiddleWareExtension
{
    public static void UseErrorMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorMiddleWare>();
    }
}
