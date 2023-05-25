using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCDataAccess.DAOs;

public class UserDAO:IUserDao
{
    private DataContext context;

    public UserDAO(DataContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }
}