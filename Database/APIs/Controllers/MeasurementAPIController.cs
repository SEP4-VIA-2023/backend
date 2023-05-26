// using EFCDataAccess;
// using EFCDataAccess.DAOs;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Model;
// using WebSockets.Gateway;
//
// namespace APIs.Controllers;
//
// [ApiController]
// [Route("api/measurements")]
// public class MeasurementAPIController : ControllerBase
// {
//     private readonly IMeasurementDAO _measurementDao;
//     private WebsocketClient clientWeb;
//     private readonly DataContext _dataContext;
//
//     public MeasurementAPIController(DataContext dataContext, IMeasurementDAO _measurementDao)
//     {
//         _dataContext = dataContext;
//         clientWeb = new WebsocketClient();
//         this._measurementDao = _measurementDao;
//     }
//
//     [HttpGet("{deviceId}")]
//     public async Task<Measurement> GetMeasurement(int id)
//     {
//         try
//         {
//             // Create the GET request URI for fetching the preset data from the IoT devic
//
//             var measurement = await _measurementDao.GetAsync(id);
//             return measurement;
//
//             // Send an HTTP GET request to the IoT device URI
//             /*HttpClient client = new HttpClient();
//             var response = client.GetAsync(getRequestUri).Result;
//
//             if (response.IsSuccessStatusCode)
//             {
//                 // Read the response content and deserialize it into a Preset object
//                 var responseContent = response.Content.ReadAsStringAsync().Result;
//                 var preset = System.Text.Json.JsonSerializer.Deserialize<Preset>(responseContent);
//                 return Ok(preset);
//             }
//             else
//             {
//                 return StatusCode((int)response.StatusCode);
//             }*/
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e);
//         }
//
//         return null;
//     }
//
//
//     [HttpPut("update/{id}"), Authorize]
//     public IActionResult UpdatePreset([FromBody] PresetDTO preset)
//     {
//         try
//         {
//             // Create the POST request URI for sending the preset data to the IoT device
//
//             // Create a JSON payload representing the updated preset
//             var jsonPayload = new
//             {
//                 id = preset.Id,
//                 name = preset.Name,
//                 minHumidity = preset.MinHumidity,
//                 maxHumidity = preset.MaxHumidity,
//                 minCo2 = preset.MinCo2,
//                 maxCo2 = preset.MaxCo2,
//                 minTemperature = preset.MinTemperature,
//                 maxTemperature = preset.MaxTemperature,
//                 deviceId = preset.DeviceId
//             };
//
//             // Convert the JSON payload to string
//             var jsonContent = new StringContent(
//                 System.Text.Json.JsonSerializer.Serialize(preset),
//                 System.Text.Encoding.UTF8,
//                 "application/json"
//             );
//
//             // Send an HTTP POST request to the IoT device URI to update the prese
//         }
//         catch (Exception e)
//         {
//             return StatusCode(500, e.Message);
//         }
//
//         return null;
//     }
//
//     [HttpPost("create"), Authorize]
//     public async Task CreatePreset([FromBody] PresetDTO preset)
//     {
//         // Create the POST request URI for sending the preset data to the IoT device
//
//         // Create a JSON payload representing the updated preset
//         var jsonPayload = new
//         {
//             id = preset.Id,
//             name = preset.Name,
//             minHumidity = preset.MinHumidity,
//             maxHumidity = preset.MaxHumidity,
//             minCo2 = preset.MinCo2,
//             maxCo2 = preset.MaxCo2,
//             minTemperature = preset.MinTemperature,
//             maxTemperature = preset.MaxTemperature,
//             servo = preset.Servo,
//             deviceId = preset.DeviceId
//         };
//         var temp = new Preset(preset.Id, preset.Name, preset.MinHumidity, preset.MaxHumidity, preset.MinCo2,
//             preset.MaxCo2, preset.MinTemperature, preset.MaxTemperature, preset.Servo, preset.DeviceId);
//         // Convert the JSON payload to string
//         var jsonContent = new StringContent(
//             System.Text.Json.JsonSerializer.Serialize(jsonPayload),
//             System.Text.Encoding.UTF8,
//             "application/json"
//         );
//
//         Preset press = await _measurementDao.CreateAsync(temp);
//         Console.WriteLine(press);
//
//         await clientWeb.ConnectAsync("ws://localhost:8080", jsonContent);
//
//
//         // Send an HTTP POST request to the IoT device URI to update the preset
//         /*HttpClient client = new HttpClient();
//         var response = client.PostAsync(postRequestUri, jsonContent).Result;*/
//
//         /*if (response.IsSuccessStatusCode)
//         {
//             return Ok();
//         }
//         else
//         {
//             return StatusCode((int)response.StatusCode);
//         }*/
//     }
// }