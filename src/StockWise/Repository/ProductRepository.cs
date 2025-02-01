using StockWise.Dto;
using StockWise.Models;
namespace StockWise.Repository;

public class ProductRepository : IProductRepository
{
  protected readonly IStockWiseContext _context;

  public ProductRepository(IStockWiseContext context)
  {
    _context = context;
  }

  public IEnumerable<Product> Get()
  {
    try
    {
      return _context.Products;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public Product Add(InsertProductDto product)
  {
    try
    {
       if (product == null)
       {
          throw new InvalidOperationException("Product is null");
       }
      
      _context.Products.Add(
          new Product
          {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            CategoryId = product.CategoryId,
            Image = product.Image
          }
      );
      _context.SaveChanges();
      var newProduct = _context.Products.First(p => p.Name == product.Name);
      return new Product
      {
        Id = newProduct.Id,
        Name = newProduct.Name,
        Description = newProduct.Description,
        Price = newProduct.Price,
        StockQuantity = newProduct.StockQuantity,
        Image = newProduct.Image
      };
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public Product Update(InsertProductDto product, int id)
  {
    try
    {
      var productToUpdate = _context.Products.First(p => p.Id == id);
      productToUpdate.Name = product.Name;
      productToUpdate.Description = product.Description;
      productToUpdate.Price = product.Price;
      productToUpdate.StockQuantity = product.StockQuantity;
      productToUpdate.Image = product.Image;
      _context.SaveChanges();
      return productToUpdate;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public void Delete(int id)
  {
    try
    {
      var productToDelete = _context.Products.First(p => p.Id == id);
      _context.Products.Remove(productToDelete);
      _context.SaveChanges();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }



}