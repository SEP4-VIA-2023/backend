using EFCDataAccess;
using EFCDataAccess.DAOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebSockets.Gateway;

namespace APIs.Controllers;

[ApiController]
[Route("api/measurements")]
public class MeasurementAPIController : ControllerBase
{
    private readonly IMeasurementDAO _measurementDao;
    private WebsocketClient clientWeb;
    private readonly DataContext _dataContext;

    public MeasurementAPIController(DataContext dataContext, IMeasurementDAO _measurementDao)
    {
        _dataContext = dataContext;
        clientWeb = new WebsocketClient();
        this._measurementDao = _measurementDao;
    }

    [HttpGet("{timestamp}"), Authorize]
    public async Task<List<Measurement>> GetAllAfterTimeMeasurement(DateTime time)
    {
        try
        {
            return await _measurementDao.GetAllAfterTimeAsync(time);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{deviceId}"), Authorize]
    public async Task<List<Measurement>> GetAllByDeviceId(int deviceId)
    {
        try
        {
            return await _measurementDao.GetAllByDeviceIdAsync(deviceId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet, Authorize]
    public async Task<List<Measurement>> GetAllAsync()
    {
        try
        {
            return await _measurementDao.GetAllAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}