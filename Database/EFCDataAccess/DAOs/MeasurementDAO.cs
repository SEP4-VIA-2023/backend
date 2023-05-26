using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCDataAccess.DAOs;

public class MeasurementDAO : IMeasurementDAO
{
    private DataContext _dataContext;

    public MeasurementDAO(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public async Task<List<Measurement>> GetAllAsync()
    {
        return await _dataContext.Measurements.ToListAsync();
    }

    public async Task<List<Measurement>> GetAllByDeviceIdAsync(int deviceId)
    {
        return await _dataContext.Measurements.Where(m => m.DeviceId == deviceId).ToListAsync();
    }

    public async Task<List<Measurement>> GetAllAfterTimeAsync(DateTime time)
    {
        return await _dataContext.Measurements.Where(m => m.Time > time).ToListAsync();
    }
}