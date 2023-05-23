using Model;

namespace EFCDataAccess;

public interface IUserDao
{
    public Task<User> CreateAsync(User user);
}