using EFCDataAccess;
using Logic.Interface;
using Logic.Security;
using Model;

namespace Logic.Logic;

public class UserLogic : IUserLogic
{
    private readonly Tokens _tokens;
    private readonly IUserDao _dataAccess;

    public UserLogic(Tokens tokens, IUserDao dataAccess)
    {
        _tokens = tokens;
        _dataAccess = dataAccess;
    }

    public async Task<UserDTO> CreateUser(UserDTO dto)
    {
        PasswordHashing.HashPassword(dto.Password!, out byte[] passwordHash, out byte[] salt);

        User? reply = await _dataAccess.GetByEmail(dto.Email!);

        if (reply != null)
        {
            throw new Exception("User with that email exists");
        }

        User created = await _dataAccess.CreateAsync(new User(dto.Name!, passwordHash, salt, dto.Email!));

        return new UserDTO(created.Name, created.Email);
    }

    public async Task<string> LoginUser(UserDTO dto)
    {
        // Retrieve user by username from DB

        User? reply = await _dataAccess.GetByEmail(dto.Email!) ?? throw new Exception("User not found");

        // Verify password

        if (!PasswordHashing.VerifyPasswordHash(dto.Password!, reply.Password!, reply.Salt!))
        {
            throw new Exception("Incorrect password");
        }

        return _tokens.CreateToken(reply);
    }
}