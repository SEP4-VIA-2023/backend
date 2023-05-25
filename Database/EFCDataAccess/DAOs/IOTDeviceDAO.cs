using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCDataAccess.DAOs;

public class IOTDeviceDAO:IIOTDeviceDAO
{
    private DataContext _dataContext;

    public IOTDeviceDAO(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IOTDevice> CreateAsync(IOTDevice iotDevice)
    {
        EntityEntry<IOTDevice> entityEntry = _dataContext.IOTDevices.Add(iotDevice);
        await _dataContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<IOTDevice?> GetByTokenAsync(string token)
    {
        IOTDevice? existing = await _dataContext.IOTDevices.FirstOrDefaultAsync(u =>
            u.Token.ToLower().Equals(token.ToLower())
        );
        return existing;
    }

    public async Task<IOTDevice?> GetByIdAsync(int id)
    {
        IOTDevice? existing = await _dataContext.IOTDevices.FirstOrDefaultAsync(u =>
            u.Id == id);
        return existing;
    }
}