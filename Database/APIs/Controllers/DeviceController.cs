using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace APIs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly IDeviceLogic _logic;

    public DeviceController(IDeviceLogic logic)
    {
        _logic = logic;
    }

    [HttpPost("create"), Authorize]
    public async Task<ActionResult<IOTDevice>> CreateDeviceAsync([FromBody] IOTDeviceDTO dto)
    {
        try
        {
            IOTDevice created = await _logic.CreateDevice(dto);

            return Created("Device has been created", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}