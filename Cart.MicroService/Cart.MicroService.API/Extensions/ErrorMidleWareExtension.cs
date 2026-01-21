using Cart.MicroService.API.MiddleWare;

namespace Cart.MicroService.API.Extensions;

public static class ErrorMidleWareExtension
{
    public static void UseErrorMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorMiddleWare>();
    }
}
