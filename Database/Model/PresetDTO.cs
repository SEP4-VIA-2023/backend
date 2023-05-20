namespace Model;

public class PresetDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MinHumidity { get; set; }
    public int MaxHumidity { get; set; }
    public int MinCo2 { get; set; }
    public int MaxCo2 { get; set; }
    public int MinTemperature { get; set; }
    public int MaxTemperature { get; set; }
    public int DeviceId { get; set; }
}