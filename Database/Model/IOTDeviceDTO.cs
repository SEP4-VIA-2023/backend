namespace Model;

public class IOTDeviceDTO
{
    public string Token { get; set; } = null!;
    public int UserId { get; set; }

    public IOTDeviceDTO(string token, int userId)
    {
        Token = token;
        UserId = userId;
    }
}