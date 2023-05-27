using Model;

namespace Logic.Interface;

public interface IUserLogic
{
    Task<UserDTO> CreateUser(UserDTO dto);
    Task<string> LoginUser(UserDTO dto);
}