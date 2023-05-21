

using Microsoft.AspNetCore.Mvc;
using Model;
using WebSockets.Gateway;

namespace APIs
{
    [ApiController]
    [Route("api/presets")]
    public class PresetsController : ControllerBase


    {
        private WebsocketClient clientWeb = new WebsocketClient();
        private readonly string iotDeviceUri = "http://your-iot-device-uri";

        [HttpGet("{deviceId}")]
        public IActionResult GetPreset(string deviceId)
        {
            try
            {
                // Create the GET request URI for fetching the preset data from the IoT device
                string getRequestUri = $"{iotDeviceUri}/{deviceId}/preset";
                
                // Send an HTTP GET request to the IoT device URI
                HttpClient client = new HttpClient();
                var response = client.GetAsync(getRequestUri).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content and deserialize it into a Preset object
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var preset = System.Text.Json.JsonSerializer.Deserialize<Preset>(responseContent);
                    return Ok(preset);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

       [HttpPut("update/{id}")]
public IActionResult UpdatePreset([FromBody] PresetDTO preset)
{
    try
    {
        // Create the POST request URI for sending the preset data to the IoT device
        string postRequestUri = $"{iotDeviceUri}/{preset.DeviceId}/preset";

        // Create a JSON payload representing the updated preset
        var jsonContent = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(preset),
            System.Text.Encoding.UTF8,
            "application/json");

        // Send an HTTP POST request to the IoT device URI to update the preset
        HttpClient client = new HttpClient();
        var response = client.PostAsync(postRequestUri, jsonContent).Result;

        if (response.IsSuccessStatusCode)
        {
            return Ok();
        }
        else
        {
            return StatusCode((int)response.StatusCode);
        }
    }
    catch (Exception e)
    {
        return StatusCode(500);
    }
}
        
        [HttpPost("create")]
        
        public async Task CreatePreset([FromBody] PresetDTO preset)
        {
            
            
                // Create the POST request URI for sending the preset data to the IoT device
                string postRequestUri = $"{iotDeviceUri}/{preset.DeviceId}/preset";
                
                // Create a JSON payload representing the updated preset
                var jsonPayload = new
                {
                    id = preset.Id,
                    name = preset.Name,
                    minHumidity = preset.MinHumidity,
                    maxHumidity = preset.MaxHumidity,
                    minCo2 = preset.MinCo2,
                    maxCo2 = preset.MaxCo2,
                    minTemperature = preset.MinTemperature,
                    maxTemperature = preset.MaxTemperature,
                    deviceId = preset.DeviceId
                };
                
                // Convert the JSON payload to string
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(jsonPayload),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );
                
                await clientWeb.ConnectAsync("ws://localhost:8080",jsonContent);

              

                // Send an HTTP POST request to the IoT device URI to update the preset
                /*HttpClient client = new HttpClient();
                var response = client.PostAsync(postRequestUri, jsonContent).Result;*/

                /*if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }*/
            }

           
        }
        
    }

