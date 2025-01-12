namespace StockWise.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
    public string? CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? Image { get; set; }
}