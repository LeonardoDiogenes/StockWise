using Microsoft.AspNetCore.Mvc;
using StockWise.Dto;
using StockWise.Models;
using StockWise.Repository;
namespace StockWise.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : Controller
{
  private readonly IUserRepository _userRepository;

  public UserController(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  [HttpGet]
  public IActionResult GetUsers()
  {
    try
    {
      var users = _userRepository.GetUsers();
      return Ok(users);
    }
    catch (Exception ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPost]
  public IActionResult AddUser([FromBody] UserDtoInput user)
  {
    try
    {
      var newUser = _userRepository.AddUser(user);
      return Created("", newUser);
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }


}



