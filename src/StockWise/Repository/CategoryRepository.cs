using StockWise.Dto;
using StockWise.Models;
namespace StockWise.Repository;

public class CategoryRepository : ICategoryRepository
{
  protected readonly IStockWiseContext _context;

  public CategoryRepository(IStockWiseContext context)
  {
    _context = context;
  }

  public IEnumerable<Category> Get()
  {
    try
    {
      return _context.Categories;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public Category Add(InsertCategoryDto category)
  {
    if (_context.Categories.Any(c => c.Name == category.Name))
    {
      throw new InvalidOperationException("Category name already exists");
    }
    
    try
    {
      _context.Categories.Add(
          new Category
          {
            Name = category.Name,
            Description = category.Description
          }
      );
      _context.SaveChanges();
      var newCategory = _context.Categories.First(c => c.Name == category.Name);
      return newCategory;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public Category Update(InsertCategoryDto category, int id)
  {
    try
    {
      var categoryToUpdate = _context.Categories.First(c => c.Id == id);
      categoryToUpdate.Name = category.Name;
      categoryToUpdate.Description = category.Description;
      _context.SaveChanges();
      return categoryToUpdate;
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
      var categoryToDelete = _context.Categories.First(c => c.Id == id);
      _context.Categories.Remove(categoryToDelete);
      _context.SaveChanges();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}