using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Storage.Entities;

namespace Storage;

public class DataContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>,
    UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>(options)
{


    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>()
        .HasMany(u => u.UserRole)
        .WithOne(ur => ur.User)
        .HasForeignKey(ur => ur.UserId)
        .IsRequired();
    modelBuilder.Entity<Role>()
        .HasMany(r => r.UserRoles)
        .WithOne(ur => ur.Role)
        .HasForeignKey(ur => ur.RoleId)
        .IsRequired();

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });

        modelBuilder.Entity<Order>()
            .HasIndex(o => o.Phone);

        modelBuilder.Entity<Role>()
            .HasData(
                new Role
                {
                    Id = Guid.Parse("ec30935e-8025-4236-9b62-aaad87a2f326"),
                    Name = Entities.Roles.Admin,
                    NormalizedName = Entities.Roles.Admin.ToUpper()
                },
                new Role
                {
                    Id = Guid.Parse("946e9393-6648-4d29-90dc-fb1c7f015336"),
                    Name = Entities.Roles.User,
                    NormalizedName = Entities.Roles.User.ToUpper()
                }
            );

        modelBuilder.Entity<OrderStatus>()
            .HasData(
             new OrderStatus {
                 Id = Guid.Parse("e0add828-035e-4fed-a27f-d31ae22ad9c2"),
                 Name = "Created"
             },
             new OrderStatus
             {
                 Id = Guid.Parse("33060dbf-ff02-43ef-90f2-66110b7a142e"),
                 Name = "InProgress"
             },
             new OrderStatus
             {
                 Id = Guid.Parse("61e0052b-ec57-410d-80e9-88eaa2fac5c7"),
                 Name = "Completed"
             }
             );
    }

}
