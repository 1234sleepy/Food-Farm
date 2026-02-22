using Gateway.API.MiddleWare;

namespace Gateway.API.Extensions;

public static class ErroMiddleWareExtension
{
    public static void UseErrorMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorMiddleWare>();
    }
}
