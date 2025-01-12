using StockWise.Models;
using StockWise.Dto;

namespace StockWise.Repository;

public interface IUserRepository
{
    IEnumerable<UserDto> GetUsers();
    UserDto AddUser(UserDtoInput user);

    UserDto UpdateUser(UserDtoInput user, int id);

    void DeleteUser(int id);
}