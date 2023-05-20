using System.ComponentModel.DataAnnotations;

namespace Model;

public class IOTDevice
{
    [Key] public int Id { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Preset> Presets { get; set; } // Navigation property
    public ICollection<Measurement> Measurements { get; set; }

    public IOTDevice(string token, int userId)
    {
        Token = token;
        UserId = userId;
    }
    private IOTDevice()
    {
        
    }
}