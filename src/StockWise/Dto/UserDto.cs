using System.ComponentModel.DataAnnotations;
namespace StockWise.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public string? Image { get; set; }
}

public class UserDtoInput
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Role { get; set; }
    [Required]
    public string? Image { get; set; }
}