using System.ComponentModel.DataAnnotations;
namespace StockWise.Dto;

public class InsertCategoryDto
{
  [Required]
  public string? Name { get; set; }
  [Required]
  public string? Description { get; set; }
}