using System.Diagnostics;

namespace Gateway.API.MiddleWare;

public class EnrichHeaderMiddleWare(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.Headers.TryAdd("ActivityId", Activity.Current?.Id);

        await _next.Invoke(context);
    }
}
