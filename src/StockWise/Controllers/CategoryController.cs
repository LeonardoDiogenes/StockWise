using Microsoft.AspNetCore.Mvc;
using StockWise.Dto;
using StockWise.Models;
using StockWise.Repository;
namespace StockWise.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoryController: Controller
{
  private readonly ICategoryRepository _categoryRepository;

  public CategoryController(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  [HttpGet]
  public IActionResult GetCategories()
  {
    try
    {
      var categories = _categoryRepository.Get();
      return Ok(categories);
    }
    catch (Exception ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPost]
  public IActionResult AddCategory([FromBody] InsertCategoryDto category)
  {
    try
    {
      var newCategory = _categoryRepository.Add(category);
      return Created("", newCategory);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPut("{id}")]
  public IActionResult UpdateCategory(int id, [FromBody] InsertCategoryDto category)
  {
    try
    {
      var updatedCategory = _categoryRepository.Update(category, id);
      return Ok(updatedCategory);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteCategory(int id)
  {
    try
    {
      _categoryRepository.Delete(id);
      return Ok();
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }
}