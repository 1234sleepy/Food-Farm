using Account.MicroService.API.MiddleWare;

namespace Account.MicroService.API.Extensions;

public static class ErroMiddleWareExtension
{
    public static void UseErrorMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorMiddleWare>();
    }
}
