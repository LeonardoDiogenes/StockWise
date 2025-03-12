using System.ComponentModel.DataAnnotations;
namespace StockWise.Dto;


public class SupplierDtoInput
{
  [Required]
  public string? Name { get; set; }
  [Required]
  public string? Contact { get; set; }
  [Required]
  public string? Address { get; set; }
}