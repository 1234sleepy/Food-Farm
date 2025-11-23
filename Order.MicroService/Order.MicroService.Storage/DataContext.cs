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
    }
}
