using System.ComponentModel.DataAnnotations;

namespace Model;

public class Measurement
{
    [Key] public int Id { get; set; }

    public int Value { get; set; }

    public DateTime Time { get; set; }

    public int Humidity { get; set; }

    public int Co2 { get; set; }

    public int Temperature { get; set; }
    public bool ServoStatus { get; set; }

    public int? DeviceId { get; set; }

    public IOTDevice? Device { get; set; }

    public Measurement(int id, int value, DateTime time, int humidity, int co2, int temperature, int? deviceId)
    {
        Id = id;
        Value = value;
        Time = time;
        Humidity = humidity;
        Co2 = co2;
        Temperature = temperature;
        DeviceId = deviceId;
    }
    private Measurement()
    {
        
    }
    
    public override string ToString()
    {
        return $"Measurement ID: {Id}\n" +
               $"Value: {Value}\n" +
               $"Time: {Time}\n" +
               $"Humidity: {Humidity}\n" +
               $"CO2: {Co2}\n" +
               $"Temperature: {Temperature}\n" +
               $"Servo Status: {ServoStatus}\n" +
               $"Device ID: {DeviceId}\n" +
               $"Device: {Device}";
    }

}