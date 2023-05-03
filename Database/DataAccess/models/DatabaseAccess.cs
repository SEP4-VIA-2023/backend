namespace DataAccess.models;

public class DatabaseAccess
{
    private readonly DatabaseContext _dbContext;

    public DatabaseAccess()
    {
        _dbContext = new DatabaseContext();
    }

    public User AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }

    public void UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }

    public List<User> GetAllUsers()
    {
        return _dbContext.Users.ToList();
    }

    public User GetUserById(int userId)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
    }
}