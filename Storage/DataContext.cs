using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }

}
