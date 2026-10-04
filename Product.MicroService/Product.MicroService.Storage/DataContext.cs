using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.Entities;

namespace Product.MicroService.Storage;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<LabelEntity> Labels { get; set; }
    public DbSet<ProductLabelEntity> ProductLabel { get; set; }
    public DbSet<ImageEntity> Images { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductLabelEntity>()
            .HasKey(pl => new { pl.ProductId, pl.LabelId });
    }
}
