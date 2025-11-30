using Microsoft.AspNetCore.Identity;

namespace Account.MicroService.Storage.Entities;

public class Role : IdentityRole<Guid>
{
    public List<UserRole>? UserRoles { get; set; }
}
