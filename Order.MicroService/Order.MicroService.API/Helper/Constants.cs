using System.Reflection;

namespace Order.MicroService.API.Helper;

public static class Constants
{
    public static string ActivitySourceName => Assembly.GetExecutingAssembly().FullName!;
    public static string ActivitySourceNameAPI => Assembly.GetExecutingAssembly().FullName! + "API";
}
