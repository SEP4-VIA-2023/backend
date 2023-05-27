using Microsoft.AspNetCore.Authorization;
using EFCDataAccess;
using EFCDataAccess.DAOs;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebSockets.Gateway;

namespace APIs
{
    [ApiController]
    [Route("api/presets")]
    public class PresetsController : ControllerBase


    {
        private readonly IMeasurementDAO _measurementDao;
        private WebsocketClient clientWeb;
        private readonly string iotDeviceUri = "http://your-iot-device-uri";
        private readonly DataContext _dataContext;
        private readonly IPresetDAO _presetDao;

        public PresetsController(DataContext dataContext)
        {
            _dataContext = dataContext;
            _presetDao = new PresetDAO(dataContext);
            _measurementDao = new MeasurementDAO(dataContext);
            clientWeb = new WebsocketClient();
        }

        [HttpGet("{deviceId}"), Authorize]
        public async Task<List<Preset>> GetPreset(int deviceId)
        {
            try
            {
                string getRequestUri = $"{iotDeviceUri}/{deviceId}/preset";

                var press = await _presetDao.GetByDeviceIdAsync(deviceId);
                return press;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdatePreset(int id, [FromBody] PresetDTO presetDTO)
        {
            try
            {
                var preset = new Preset
                (
                    id,
                    presetDTO.Name,
                    presetDTO.MinHumidity,
                    presetDTO.MaxHumidity,
                    presetDTO.MinCo2,
                    presetDTO.MaxCo2,
                    presetDTO.MinTemperature,
                    presetDTO.MaxTemperature,
                    presetDTO.Servo,
                    presetDTO.DeviceId
                );

                await _presetDao.UpdateAsync(id, preset);

                // Return a response indicating the update was successful
                return Ok("Preset updated successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("create"), Authorize]
        public async Task CreatePreset([FromBody] PresetDTO preset)
        {
            
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
                servo = preset.Servo,
                deviceId = preset.DeviceId
            };
            var temp = new Preset(preset.Id, preset.Name, preset.MinHumidity, preset.MaxHumidity, preset.MinCo2,
                preset.MaxCo2, preset.MinTemperature, preset.MaxTemperature, preset.Servo, preset.DeviceId);

            Preset press = await _presetDao.CreateAsync(temp);
 



         
            


        }
    }
}