using Microsoft.AspNetCore.Identity;

namespace Account.MicroService.Storage.Entities;

public class User : IdentityUser<Guid>
{
    public List<UserRole>? UserRole { get; set; }
}

