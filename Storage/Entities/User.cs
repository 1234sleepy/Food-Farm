using Microsoft.AspNetCore.Identity;

namespace Storage.Entities;

public class User : IdentityUser<Guid>
{
    public List<UserRole>? UserRole { get; set; }
}
