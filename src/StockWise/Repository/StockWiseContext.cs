using Microsoft.EntityFrameworkCore;
using StockWise.Models;

namespace StockWise.Repository;

public class StockWiseContext : DbContext, IStockWiseContext
{

  public DbSet<User> Users { get; set; } = null!;

  public DbSet<Product> Products { get; set; } = null!;

  public DbSet<Supplier> Suppliers { get; set; } = null!;

  public DbSet<Category> Categories { get; set; } = null!;

  public DbSet<Inventory_Log> Inventory_Logs { get; set; } = null!;

  public StockWiseContext(DbContextOptions<StockWiseContext> options) : base(options)
  {
  }

  public StockWiseContext()
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      var configuration = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .Build();
      optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
      optionsBuilder.EnableSensitiveDataLogging();
    }
  }


}