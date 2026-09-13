namespace Product.MicroService.API.Extensions;

public static class HttpRequestExtension
{
    public static Guid GetUserId(this HttpRequest request)
    {
        return request.Headers.TryGetValue("UserId", out var UserId) ? new Guid(UserId) : Guid.Empty;
    }


}
