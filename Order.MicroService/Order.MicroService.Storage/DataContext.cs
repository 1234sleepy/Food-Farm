using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Order.MicroService.Storage;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<DetailOrder> Orders { get; set; }
    public DbSet<OrderItem>  OrderItems{ get; set; }
    public DbSet<OrderStatus> OrderStatuses{ get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });

        modelBuilder.Entity<DetailOrder>()
            .HasIndex(o => o.Phone);

        modelBuilder.Entity<OrderStatus>()
            .HasData(
             new OrderStatus
             {
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
