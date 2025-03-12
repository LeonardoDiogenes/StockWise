using StockWise.Dto;
using StockWise.Models;
namespace StockWise.Repository;

public class InventoryLogRepository : IInventoryLogRepository
{
    protected readonly IStockWiseContext _context;

    public InventoryLogRepository(IStockWiseContext context)
    {
        _context = context;
    }

    public IEnumerable<Inventory_Log> GetInventoryLogs()
    {
        try
        {
            return _context.Inventory_Logs;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Inventory_Log AddInventoryLog(InventoryLogDtoInput inventoryLog)
    {
        try
        {
            _context.Inventory_Logs.Add(
                new Inventory_Log
                {
                    ProductId = inventoryLog.ProductId,
                    Quantity = inventoryLog.Quantity,
                    Date = DateTime.Now,
                    Type = inventoryLog.Type
                }
            );
            _context.SaveChanges();
            return _context.Inventory_Logs.Find(inventoryLog.ProductId)!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Inventory_Log UpdateInventoryLog(InventoryLogDtoInput inventoryLog, int id)
    {
        try
        {
            var inventoryLogToUpdate = _context.Inventory_Logs.Find(id);
            if (inventoryLogToUpdate == null)
            {
                throw new InvalidOperationException("Inventory log not found");
            }
            inventoryLogToUpdate.Quantity = inventoryLog.Quantity;
            inventoryLogToUpdate.Type = inventoryLog.Type;
            inventoryLogToUpdate.Notes = inventoryLog.Notes;
            inventoryLogToUpdate.ProductId = inventoryLog.ProductId;
            _context.SaveChanges();
            return inventoryLogToUpdate;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void DeleteInventoryLog(int id)
    {
        try
        {
            var inventoryLogToDelete = _context.Inventory_Logs.Find(id);
            if (inventoryLogToDelete == null)
            {
                throw new InvalidOperationException("Inventory log not found");
            }
            _context.Inventory_Logs.Remove(inventoryLogToDelete);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
