using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using EFCDataAccess.DAOs;
using Model;

namespace APIs.Controllers;

public class MeasurementConverter
{
    public int GetTemperature(string data)
    {
        byte[] bytes = new byte[data.Length / 2];

        for (int i = 0; i < data.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
        }

        int temperature = (bytes[4] << 8) | bytes[5];
        return temperature;
    }

    public int GetHumidity(string data)
    {
        byte[] bytes = new byte[data.Length / 2];

        for (int i = 0; i < data.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
        }

        int humidity = (bytes[2] << 8) | bytes[3];
        return humidity;
    }


    public int GetCO2(string data)
    {
        byte[] bytes = new byte[data.Length / 2];

        for (int i = 0; i < data.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
        }

        int co2_ppm = (bytes[0] << 8) | bytes[1];
        return co2_ppm;
    }

  public int GetServo(string data)
    {
        byte[] bytes = new byte[data.Length / 2];

        for (int i = 0; i < data.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
        }

        int servoStatus = bytes[6] & 0xFF;
        return servoStatus;
    }

    public MeasurementConverter()
    {
    }
}