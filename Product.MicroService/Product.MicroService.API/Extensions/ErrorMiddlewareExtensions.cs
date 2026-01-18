using Product.MicroService.API.Extensions.Error;
using System.Runtime.CompilerServices;

namespace Product.MicroService.API.Extensions;

public static class ErrorMiddlewareExtensions
{
    public static void UseErrorMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorMiddleWare>();
    }
}
