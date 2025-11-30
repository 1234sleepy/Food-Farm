using Microsoft.EntityFrameworkCore;

namespace Cart.MicroService.Storage;

public class DataContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


    }
}
