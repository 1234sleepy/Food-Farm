using System.Diagnostics;

namespace Product.MicroService.API.MidddleWare;

public class MonitoringMiddleWare(RequestDelegate next)
{
    private static readonly ActivitySource ActivitySource = new("ProducMicroService");
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if(context.Request.Headers.TryGetValue("ActivityId", out var activityId))
        {
            using var activity = ActivitySource.StartActivity("", ActivityKind.Internal, ActivityContext.TryParse(activityId, null, out var activityContext) ? activityContext : default);
        }

        await _next.Invoke(context);
    }
}
