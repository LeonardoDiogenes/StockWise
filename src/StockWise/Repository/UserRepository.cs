using StockWise.Dto;
using StockWise.Models;
namespace StockWise.Repository;

public class UserRepository : IUserRepository
{
  protected readonly IStockWiseContext _context;

  public UserRepository(IStockWiseContext context)
  {
    _context = context;
  }

  public IEnumerable<UserDto> GetUsers()
  {
    try
    {
      return _context.Users.Select(u => new UserDto
      {
        Id = u.Id,
        Name = u.Name,
        Email = u.Email,
        Role = u.Role
      });
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public UserDto AddUser(UserDtoInput user)
  {
    if (_context.Users.Any(u => u.Email == user.Email))
    {
      throw new InvalidOperationException("User email already exists");
    }

    try
    {
      _context.Users.Add(
          new User
          {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Role = "employee",
            Image = user.Image
          }
      );
      _context.SaveChanges();
      var newUser = _context.Users.First(u => u.Email == user.Email);
      return new UserDto
      {
        Id = newUser.Id,
        Name = newUser.Name,
        Email = newUser.Email,
        Role = newUser.Role
      };
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public UserDto UpdateUser(UserDtoInput user, int userId)
  {
    var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == userId);
    if (userToUpdate == null)
    {
      throw new InvalidOperationException("User not found");
    }
    if (user.Name != null)
    {
      userToUpdate.Name = user.Name;
    }
    if (user.Email != null)
    {
      userToUpdate.Email = user.Email;
    }
    if (user.Role != null)
    {
      userToUpdate.Role = user.Role;
    }
    if (user.Password != null)
    {
      userToUpdate.Password = user.Password;
    }
    if (user.Image != null)
    {
      userToUpdate.Image = user.Image;
    }
    _context.SaveChanges();
    return new UserDto
    {
      Id = userToUpdate.Id,
      Name = userToUpdate.Name,
      Email = userToUpdate.Email,
      Role = userToUpdate.Role
    };
  }

  public void DeleteUser(int userId)
  {
    var userToDelete = _context.Users.FirstOrDefault(u => u.Id == userId);
    if (userToDelete == null)
    {
      throw new InvalidOperationException("User not found");
    }
    _context.Users.Remove(userToDelete);
    _context.SaveChanges();
  }


}