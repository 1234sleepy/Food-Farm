using API.Core.MiddleWare;

namespace API.Core.Extensions;

public static class ErrorMiddleWareExtensions
{
    public static void UseErrorMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorMiddleWare>();
    }
}
