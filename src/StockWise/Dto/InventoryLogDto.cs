using System.ComponentModel.DataAnnotations;
namespace StockWise.Dto;

public class InventoryLogDtoInput
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public string? Type { get; set; }
    [Required]
    public string? Notes { get; set; }

}