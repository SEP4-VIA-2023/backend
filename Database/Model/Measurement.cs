using System.ComponentModel.DataAnnotations;

namespace Model;

public class Measurement
{
    [Key] public int Id { get; set; }
    

    public DateTime Time { get; set; }

    public int Humidity { get; set; }

    public int Co2 { get; set; }

    public int Temperature { get; set; }
    
    public int ServoStatus { get; set; }

    public int? DeviceId { get; set; }

    public IOTDevice? Device { get; set; }
    
    public Measurement(int id,DateTime time, int humidity, int co2, int temperature,int servoStatus, int? deviceId)

    {
        Id = id;
    
        Time = time;
        Humidity = humidity;
        Co2 = co2;
        Temperature = temperature;
        ServoStatus = servoStatus;
        DeviceId = deviceId;
    }
    public Measurement()
    {
        
    }

   

    public override string ToString()
    {
        return $"Measurement ID: {Id}\nTime: {Time}\nHumidity: {Humidity}\nCO2: {Co2}\nTemperature: {Temperature}\nServo Status: {ServoStatus}\nDevice ID: {DeviceId}";
    }



}