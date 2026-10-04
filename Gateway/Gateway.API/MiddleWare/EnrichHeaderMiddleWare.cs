using Gateway.API.Extensions;
using System.Diagnostics;

namespace Gateway.API.MiddleWare;

public class EnrichHeaderMiddleWare(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if(context.User?.Identity?.IsAuthenticated ?? false)
        {
            context.Request.Headers.TryAdd("ActivityId", Activity.Current?.Id);
            context.Request.Headers.TryAdd("UserId", context.User.GetUserId().ToString());
            context.Request.Headers.TryAdd("UserRole", String.Join(',', context.User.GetUserRoles()));
        }

        await _next.Invoke(context);
    }
}
