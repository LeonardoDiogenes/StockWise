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
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public string? Image { get; set; }
}