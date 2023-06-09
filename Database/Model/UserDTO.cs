namespace Model;

public class UserDTO
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public UserDTO(string name, string email)
    {
        Name = name;
        Email = email;
    }
}