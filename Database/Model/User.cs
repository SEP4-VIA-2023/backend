using System.ComponentModel.DataAnnotations;

namespace Model;

public class User
{[Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public List<IOTDevice> IOTDevices { get; set; } = null!;

    public User(int id, string name, string password, string email)
    {
        Id = id;
        Name = name;
        Password = password;
        Email = email;
    }
    private User()
    {
        
    }
}