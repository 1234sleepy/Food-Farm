﻿using Microsoft.AspNetCore.Identity;

namespace Storage.Entities;

public class Role : IdentityRole<Guid>
{
    public List<UserRole>? UserRoles { get; set; }
}
