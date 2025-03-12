using Microsoft.AspNetCore.Mvc;
using StockWise.Dto;
using StockWise.Models;
using StockWise.Repository;
namespace StockWise.Controllers;

[ApiController]
[Route("[controller]")]

public class InventoryLogController : Controller
{
  private readonly IInventoryLogRepository _inventoryLogRepository;

  public InventoryLogController(IInventoryLogRepository inventoryLogRepository)
  {
    _inventoryLogRepository = inventoryLogRepository;
  }

  [HttpGet]
  public IActionResult GetInventoryLogs()
  {
    try
    {
      var inventoryLogs = _inventoryLogRepository.GetInventoryLogs();
      return Ok(inventoryLogs);
    }
    catch (Exception ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPost]
  public IActionResult AddInventoryLog([FromBody] InventoryLogDtoInput inventoryLog)
  {
    try
    {
      var newInventoryLog = _inventoryLogRepository.AddInventoryLog(inventoryLog);
      return Created("", newInventoryLog);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPut("{id}")]
  public IActionResult UpdateInventoryLog(int id, [FromBody] InventoryLogDtoInput inventoryLog)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    try
    {
      var updatedInventoryLog = _inventoryLogRepository.UpdateInventoryLog(inventoryLog, id);
      return Ok(updatedInventoryLog);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteInventoryLog(int id)
  {
    try
    {
      _inventoryLogRepository.DeleteInventoryLog(id);
      return Ok();
    }
    catch (Exception ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }


}