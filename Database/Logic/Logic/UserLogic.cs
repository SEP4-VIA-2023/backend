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

        Console.WriteLine(passwordHash);
        Console.WriteLine(salt);

        return dto;
    }

    public string LoginUser(UserDTO dto)
    {
        // Retrieve user by username from DB

        // Not implemented
        // int id, string name, byte[] password, byte[] salt, string email

        User reply = new(1, "Temp", new byte[] { 0x20, 0x20, 0x20 }, new byte[] { 0x20, 0x20, 0x20 }, "email@example.com");

        // Verify password

        // if (!PasswordHashing.VerifyPasswordHash(dto.Password!, reply.Password!, reply.Salt!))
        // {
        //     throw new Exception("Incorrect password");
        // }

        return _tokens.CreateToken(reply);
    }
}