using Cart.MicroService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cart.MicroService.Storage;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<CartEntity> Cart { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CartEntity>()
        .HasKey(c => new { c.UserId, c.ProductId });
    }
}
