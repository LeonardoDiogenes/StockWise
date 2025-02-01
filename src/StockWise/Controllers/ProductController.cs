using Microsoft.AspNetCore.Mvc;
using StockWise.Dto;
using StockWise.Models;
using StockWise.Repository;
namespace StockWise.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController : Controller
{
  private readonly IProductRepository _productRepository;

  public ProductController(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  [HttpGet]
  public IActionResult GetProducts()
  {
    try
    {
      var products = _productRepository.Get();
      return Ok(products);
    }
    catch (Exception ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPost]
  public IActionResult AddProduct([FromBody] InsertProductDto product)
  {
    try
    {
      var newProduct = _productRepository.Add(product);
      return Created("", newProduct);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPut("{id}")]
  public IActionResult UpdateProduct(int id, [FromBody] InsertProductDto product)
  {
    try
    {
      var updatedProduct = _productRepository.Update(product, id);
      return Ok(updatedProduct);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteProduct(int id)
  {
    try
    {
      _productRepository.Delete(id);
      return NoContent();
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

}