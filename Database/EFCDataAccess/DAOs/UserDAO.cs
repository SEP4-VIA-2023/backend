using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCDataAccess.DAOs;

public class UserDAO : IUserDao
{
    private readonly DataContext _context;

    public UserDAO(DataContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByEmail(string email)
    {
        User? exists = await _context.Users.FirstOrDefaultAsync(u =>
        u.Email == email);

        return exists;
    }
}