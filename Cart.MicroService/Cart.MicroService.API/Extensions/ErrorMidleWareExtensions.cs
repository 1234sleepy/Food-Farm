using Cart.MicroService.API.MiddleWare;

namespace Cart.MicroService.API.Extensions;

public static class ErrorMidleWareExtensions
{
    public static void UseErrorMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorMiddleWare>();
    }
}
