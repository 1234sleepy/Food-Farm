using System.Security.Claims;

namespace Gateway.API.Extensions;

public static class ClaimsPrincipalExtension
{
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        Guid.TryParse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);

        return userId;
    }

    public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirst(ClaimTypes.Name)!.Value;
    }

    public static List<string> GetUserRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirst(ClaimTypes.Role)!.Value.Split(",").ToList();
    }
}