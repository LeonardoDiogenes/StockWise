using StockWise.Models;
using StockWise.Dto;

namespace StockWise.Repository;

public interface IInventoryLogRepository
{
  IEnumerable<Inventory_Log> GetInventoryLogs();
  Inventory_Log AddInventoryLog(InventoryLogDtoInput inventoryLog);
  Inventory_Log UpdateInventoryLog(InventoryLogDtoInput inventoryLog, int id);
  void DeleteInventoryLog(int id);

}