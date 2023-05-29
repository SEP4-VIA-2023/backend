using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model;

public class Preset
{
    [Key] public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MinHumidity { get; set; }

    public int MaxHumidity { get; set; }

    public int MinCo2 { get; set; }

    public int MaxCo2 { get; set; }

    public int MinTemperature { get; set; }

    public int MaxTemperature { get; set; }

    public int Servo { get; set; }

    public int? DeviceId { get; set; }
    public bool isActive { get; set; } = false;
    public IOTDevice? Device { get; set; }

    public Preset(int id, string name, int minHumidity, int maxHumidity, int minCo2, int maxCo2, int minTemperature,
        int maxTemperature, int servo, int? deviceId, bool isActive)
    {
        Id = id;
        Name = name;
        MinHumidity = minHumidity;
        MaxHumidity = maxHumidity;
        MinCo2 = minCo2;
        MaxCo2 = maxCo2;
        MinTemperature = minTemperature;
        MaxTemperature = maxTemperature;
        Servo = servo;
        DeviceId = deviceId;
       this.isActive = isActive;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Name: {Name}");
        sb.AppendLine($"MinHumidity: {MinHumidity}");
        sb.AppendLine($"MaxHumidity: {MaxHumidity}");
        sb.AppendLine($"MinCo2: {MinCo2}");
        sb.AppendLine($"MaxCo2: {MaxCo2}");
        sb.AppendLine($"MinTemperature: {MinTemperature}");
        sb.AppendLine($"MaxTemperature: {MaxTemperature}");
        sb.AppendLine($"Servo: {Servo}");
        sb.AppendLine($"DeviceId: {DeviceId}");
        return sb.ToString();
    }


    private Preset()
    {
    }
}