using System.ComponentModel.DataAnnotations;
using StockWise.Models;
namespace StockWise.Dto;

public class InsertProductDto
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public int? CategoryId { get; set; }

    public string? Image { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
}

