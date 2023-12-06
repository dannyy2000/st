using Microsoft.EntityFrameworkCore;

namespace WebApplication1.data.models;


public class StockDbContext : DbContext
{



    public DbSet<Stock> Stocks { get; set; }
    public DbSet<User> Users { get; set; }

    public StockDbContext(DbContextOptions options) : base(options)
    {
        Stocks = Set<Stock>();
        Users = Set<User>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Stock>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();

    }
}


