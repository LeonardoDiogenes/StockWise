namespace StockWise.Models;

public class Inventory_Log
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public string? Type { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
}