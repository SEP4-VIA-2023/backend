using Model;

namespace EFCDataAccess;

public interface IIOTDeviceDAO
{
    public Task<IOTDevice> CreateAsync(IOTDevice iotDevice);
    public Task<IOTDevice?> GetByTokenAsync(string token);
    public Task<IOTDevice?> GetByIdAsync(int id);
}