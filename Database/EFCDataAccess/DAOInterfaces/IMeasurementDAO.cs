using Model;

namespace EFCDataAccess;

public interface IMeasurementDAO
{
    public Task<List<Measurement>> GetAllAsync();
    public Task<List<Measurement>> GetAllByDeviceIdAsync(int deviceId);
    public Task<List<Measurement>> GetAllAfterTimeAsync(DateTime time);
}