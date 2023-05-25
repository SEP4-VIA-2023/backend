using Logic.Interface;
using Logic.Security;
using Model;

namespace Logic.Logic;

public class UserLogic : IUserLogic
{
    private readonly Tokens _tokens;

    public UserLogic(Tokens tokens)
    {
        _tokens = tokens;
    }
    public UserDTO CreateUser(UserDTO dto)
    {
        PasswordHashing.HashPassword(dto.Password!, out byte[] passwordHash, out byte[] salt);

        throw new NotImplementedException();
    }

    public string LoginUser(UserDTO dto)
    {
        // Retrieve user by username from DB

        // Not implemented

        User reply = new();

        // Verify password

        if (!PasswordHashing.VerifyPasswordHash(dto.Password!, reply.Password!, reply.Salt!))
        {
            throw new Exception("Incorrect password");
        }

        return _tokens.CreateToken(reply);
    }
}