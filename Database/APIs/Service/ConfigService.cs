using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class ConfigService
{
    private readonly HttpClient _httpClient;

    public ConfigService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<ushort> GetMinCO2Value()
    {
        JObject configurationJson = await GetConfigurationJson();
        return configurationJson["minCO2"].Value<ushort>();
    }

    public async Task<ushort> GetMaxCO2Value()
    {
        JObject configurationJson = await GetConfigurationJson();
        return configurationJson["maxCO2"].Value<ushort>();
    }

    public async Task<ushort> GetMinHumidityValue()
    {
        JObject configurationJson = await GetConfigurationJson();
        return configurationJson["minHumidity"].Value<ushort>();
    }

    public async Task<ushort> GetMaxHumidityValue()
    {
        JObject configurationJson = await GetConfigurationJson();
        return configurationJson["maxHumidity"].Value<ushort>();
    }

    public async Task<short> GetMinTempValue()
    {
        JObject configurationJson = await GetConfigurationJson();
        return configurationJson["minTemp"].Value<short>();
    }

    public async Task<short> GetMaxTempValue()
    {
        JObject configurationJson = await GetConfigurationJson();
        return configurationJson["maxTemp"].Value<short>();
    }

    public async Task<sbyte> GetRotationPercentageValue()
    {
        JObject configurationJson = await GetConfigurationJson();
        return configurationJson["rotationPercentage"].Value<sbyte>();
    }

    private async Task<JObject> GetConfigurationJson()
    {
        string apiUrl = "http://localhost:8080/api/presets/1"; // Replace with your actual API endpoint

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync();
        JObject configurationJson = JObject.Parse(responseContent);

        return configurationJson;
    }
    public async Task<string> ConfigurationToString()
    {
        ushort minCO2 = await GetMinCO2Value();
        ushort maxCO2 = await GetMaxCO2Value();
        ushort minHumidity = await GetMinHumidityValue();
        ushort maxHumidity = await GetMaxHumidityValue();
        short minTemp = await GetMinTempValue();
        short maxTemp = await GetMaxTempValue();
        sbyte rotationPercentage = await GetRotationPercentageValue();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Configuration values:");
        sb.AppendLine($"Minimum CO2: {minCO2}");
        sb.AppendLine($"Maximum CO2: {maxCO2}");
        sb.AppendLine($"Minimum Humidity: {minHumidity}");
        sb.AppendLine($"Maximum Humidity: {maxHumidity}");
        sb.AppendLine($"Minimum Temperature: {minTemp}");
        sb.AppendLine($"Maximum Temperature: {maxTemp}");
        sb.AppendLine($"Rotation Percentage: {rotationPercentage}");

        return sb.ToString();
    }
}

