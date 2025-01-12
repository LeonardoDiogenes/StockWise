using Microsoft.EntityFrameworkCore;
using StockWise.Models;

namespace StockWise.Repository;

public interface IStockWiseContext
{
  public DbSet<User> Users { get; set; }

  public DbSet<Product> Products { get; set; }

  public DbSet<Supplier> Suppliers { get; set; }

  public DbSet<Category> Categories { get; set; }

  public DbSet<Inventory_Log> Inventory_Logs { get; set; }

  public int SaveChanges();
}