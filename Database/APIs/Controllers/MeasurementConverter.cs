public class MeasurementConverter
{
    public int GetTemperature(string data)
    {
        try
        {
            byte[] bytes = new byte[data.Length / 2];

            for (int i = 0; i < data.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
            }

            int temperature = (bytes[4] << 8) | bytes[5];
            return temperature / 10;
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid data format. The input data must be a hexadecimal string.");
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("Invalid data length. The input data length must be even and sufficient for extracting temperature.");
        }
    }

    public int GetHumidity(string data)
    {
        try
        {
            byte[] bytes = new byte[data.Length / 2];

            for (int i = 0; i < data.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
            }

            int humidity = (bytes[2] << 8) | bytes[3];
            return humidity / 10;
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid data format. The input data must be a hexadecimal string.");
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("Invalid data length. The input data length must be even and sufficient for extracting humidity.");
        }
    }

    public int GetCO2(string data)
    {
        try
        {
            byte[] bytes = new byte[data.Length / 2];

            for (int i = 0; i < data.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
            }

            int co2_ppm = (bytes[0] << 8) | bytes[1];
            return co2_ppm;
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid data format. The input data must be a hexadecimal string.");
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("Invalid data length. The input data length must be even and sufficient for extracting CO2 ppm.");
        }
    }

    public int GetServo(string data)
    {
        try
        {
            byte[] bytes = new byte[data.Length / 2];

            for (int i = 0; i < data.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
            }

            int servoStatus = bytes[6] & 0xFF;
            return servoStatus;
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid data format. The input data must be a hexadecimal string.");
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentException("Invalid data length. The input data length must be even and sufficient for extracting servo status.");
        }
    }
}
