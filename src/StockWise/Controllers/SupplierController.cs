using Microsoft.AspNetCore.Mvc;
using StockWise.Dto;
using StockWise.Models;
using StockWise.Repository;
namespace StockWise.Controllers;

[ApiController]
[Route("[controller]")]

public class SupplierController : Controller
{
  private readonly ISupplierRepository _supplierRepository;

  public SupplierController(ISupplierRepository supplierRepository)
  {
    _supplierRepository = supplierRepository;
  }

  [HttpGet]
  public IActionResult GetSuppliers()
  {
    try
    {
      var suppliers = _supplierRepository.GetSuppliers();
      return Ok(suppliers);
    }
    catch (Exception ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPost]
  public IActionResult AddSupplier([FromBody] SupplierDtoInput supplier)
  {
    try
    {
      var newSupplier = _supplierRepository.AddSupplier(supplier);
      return Created("", newSupplier);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPut("{id}")]
  public IActionResult UpdateSupplier(int id, [FromBody] SupplierDtoInput supplier)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    try
    {
      var updatedSupplier = _supplierRepository.UpdateSupplier(supplier, id);
      return Ok(updatedSupplier);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteSupplier(int id)
  {
    try
    {
      _supplierRepository.DeleteSupplier(id);
      return Ok();
    }
    catch (Exception ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }
}