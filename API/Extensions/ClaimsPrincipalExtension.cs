using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipalExtension
{
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        Guid.TryParse(claimsPrincipal.FindFirst("UserId")?.Value, out Guid userId);

        return userId;
    }
}