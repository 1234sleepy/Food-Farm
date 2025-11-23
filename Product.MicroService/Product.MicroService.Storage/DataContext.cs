using Microsoft.EntityFrameworkCore;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ProductE> Products { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<ProductLabel> ProductLabel { get; set; }
    public DbSet<Image> Images { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductLabel>()
            .HasKey(pl => new { pl.ProductId, pl.LabelId });
    }
}
