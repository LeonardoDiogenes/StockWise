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

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>().HasData(
      new User
      {
        Id = 1,
        Name = "Admin",
        Email = "admin@stockwise.com",
        Password = "admin123", // Em um cenário real, use hash para senhas!
        Role = "Admin",
        Image = "https://example.com/images/admin.jpg"
      },
       new User
       {
         Id = 2,
         Name = "User",
         Email = "user@stockwise.com",
         Password = "user123", // Em um cenário real, use hash para senhas!
         Role = "User",
         Image = "https://example.com/images/user.jpg"
       }
    );

    modelBuilder.Entity<Category>().HasData(
      new Category
      {
        Id = 1,
        Name = "Eletrônicos"
      },
      new Category
      {
        Id = 2,
        Name = "Informática"
      },
      new Category
      {
        Id = 3,
        Name = "Celulares"
      }
    );

    modelBuilder.Entity<Supplier>().HasData(
        new Supplier
        {
          Id = 1,
          Name = "Tech Supplier Inc.",
          Contact = "contact@techsupplier.com",
          Address = "123 Tech Street, Tech City"
        },
        new Supplier
        {
          Id = 2,
          Name = "Fashion Supplier Ltd.",
          Contact = "info@fashionsupplier.com",
          Address = "456 Fashion Avenue, Style City"
        }
    );

    modelBuilder.Entity<Product>().HasData(
        new Product
        {
          Id = 1,
          Name = "Smartphone X",
          Description = "A latest generation smartphone with advanced features.",
          Price = 999.99,
          StockQuantity = 50,
          CategoryId = 1, // Relacionado à categoria "Electronics"
          Image = "https://example.com/images/smartphone-x.jpg"
        },
        new Product
        {
          Id = 2,
          Name = "Laptop Pro",
          Description = "A high-performance laptop for professionals.",
          Price = 1499.99,
          StockQuantity = 30,
          CategoryId = 1, // Relacionado à categoria "Electronics"
          Image = "https://example.com/images/laptop-pro.jpg"
        },
        new Product
        {
          Id = 3,
          Name = "T-Shirt Casual",
          Description = "A comfortable and stylish t-shirt.",
          Price = 29.99,
          StockQuantity = 100,
          CategoryId = 2, // Relacionado à categoria "Clothing"
          Image = "https://example.com/images/tshirt-casual.jpg"
        }
    );
  }


}