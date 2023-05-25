using Model;

namespace EFCDataAccess;

public interface IMeasurementDAO
{
    public Task<Measurement> CreateAsync(Measurement measurement);
    public Task<Measurement?> GetAsync(int id);
    public Task<List<Measurement>> GetAllAsync();
}