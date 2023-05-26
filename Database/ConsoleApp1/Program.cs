
using System;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConfigService cfg = new ConfigService();
            ushort minCO2 = await cfg.GetMinCO2Value();
            ushort maxCO2 = await cfg.GetMaxCO2Value();
            ushort minHumidity = await cfg.GetMinHumidityValue();
            ushort maxHumidity = await cfg.GetMaxHumidityValue();
            short minTemp = await cfg.GetMinTempValue();
            short maxTemp = await cfg.GetMaxTempValue();
            sbyte rotationPercentage = await cfg.GetRotationPercentageValue();

            Console.WriteLine(cfg.ConfigurationToString());

            // Rest of your code...
        }
    }
}
;