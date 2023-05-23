using Model;

namespace Logic.Interface;

public interface IUserLogic
{
    UserDTO CreateUser(UserDTO dto);
    string LoginUser(UserDTO dto);
}